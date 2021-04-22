using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IEXSharp.Helper
{
	/// <summary> Allow both quoted and unquoted numbers on  deserialize. </summary>
	public class StringConverter : JsonConverter<string>
	{
		public override string Read(ref Utf8JsonReader reader, Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.String)
			{
				return reader.GetString();
			}
			else if (reader.TokenType == JsonTokenType.True)
			{
				return "true";
			}
			else if (reader.TokenType == JsonTokenType.False)
			{
				return "false";
			}
			else if (reader.TokenType == JsonTokenType.Number)
			{
				if (reader.TryGetInt64(out long l))
				{
					return l.ToString();
				}
				else
				{
					return reader.GetDecimal().ToString();
				}
			}
			else if (reader.TokenType == JsonTokenType.Null)
			{
				return null;
			}
			else if (reader.TokenType == JsonTokenType.StartArray)
			{
				using (var doc = JsonDocument.ParseValue(ref reader))
				{
					return doc.RootElement.GetRawText();
				}
			}
			else
			{
				throw new JsonException();
			}
		}

		public override void Write(Utf8JsonWriter writer, string value,
			JsonSerializerOptions options) => writer.WriteStringValue(value);
	}

	public class DateTimeConverter : JsonConverter<DateTime?>
	{
		public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.String &&
				typeToConvert == typeof(DateTime?))
			{
				var stringValue = reader.GetString();
				if (DateTime.TryParse(stringValue, out var value))
				{
					return value;
				}
				return null;
			}
			throw new JsonException();
		}

		public override void Write(Utf8JsonWriter writer, DateTime? input,
			JsonSerializerOptions options)
		{
			if (input.HasValue)
			{
				writer.WriteStringValue(input.Value);
			}
			else
			{
				writer.WriteNullValue();
			}
		}
	}

	/// <summary>
	/// Allow dictionaries with key of type DateTime (System.Text.Json only supports keys of type string)
	/// </summary>
	public class DictionaryDatetimeTValueConverter : JsonConverterFactory
	{// https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-converters-how-to#registration-sample---converters-collection
		public override bool CanConvert(Type typeToConvert)
		{
			if (!typeToConvert.IsGenericType)
			{
				return false;
			}

			if (typeToConvert.GetGenericTypeDefinition() != typeof(Dictionary<,>))
			{
				return false;
			}

			return typeToConvert.GetGenericArguments()[0] == typeof(DateTime);
		}

		public override JsonConverter CreateConverter(
			Type type,
			JsonSerializerOptions options)
		{
			Type keyType = type.GetGenericArguments()[0]; // should be DateTime
			Type valueType = type.GetGenericArguments()[1];

			return (JsonConverter)Activator.CreateInstance(
				typeof(DictionaryDatetimeConverterInner<>).MakeGenericType(
					new Type[] { valueType }),
				BindingFlags.Instance | BindingFlags.Public,
				binder: null,
				args: new object[] { options },
				culture: null);
		}

		private class DictionaryDatetimeConverterInner<TValue> :
			JsonConverter<Dictionary<DateTime, TValue>>
		{
			private readonly JsonConverter<TValue> _valueConverter;
			private Type _keyType;
			private Type _valueType;

			public DictionaryDatetimeConverterInner(JsonSerializerOptions options)
			{
				// For performance, use the existing converter if available.
				_valueConverter = (JsonConverter<TValue>)options
					.GetConverter(typeof(TValue));

				// Cache the key and value types.
				_keyType = typeof(DateTime);
				_valueType = typeof(TValue);
			}

			public override Dictionary<DateTime, TValue> Read(
				ref Utf8JsonReader reader,
				Type typeToConvert,
				JsonSerializerOptions options)
			{
				if (reader.TokenType != JsonTokenType.StartObject)
				{
					throw new JsonException();
				}

				Dictionary<DateTime, TValue> dictionary = new Dictionary<DateTime, TValue>();

				while (reader.Read())
				{
					if (reader.TokenType == JsonTokenType.EndObject)
					{
						return dictionary;
					}

					// Get the key.
					if (reader.TokenType != JsonTokenType.PropertyName)
					{
						throw new JsonException();
					}

					string propertyName = reader.GetString();

					// For performance, parse with ignoreCase:false first.
					if (!DateTime.TryParseExact(propertyName, "yyyyMMdd", null,
						System.Globalization.DateTimeStyles.None, out DateTime key))
					{
						throw new JsonException(
							$"Unable to convert \"{propertyName}\" to DateTime.");
					}

					// Get the value.
					TValue v;
					if (_valueConverter != null)
					{
						reader.Read();
						v = _valueConverter.Read(ref reader, _valueType, options);
					}
					else
					{
						v = JsonSerializer.Deserialize<TValue>(ref reader, options);
					}

					// Add to dictionary.
					dictionary.Add(key, v);
				}

				throw new JsonException();
			}

			public override void Write(
				Utf8JsonWriter writer,
				Dictionary<DateTime, TValue> dictionary,
				JsonSerializerOptions options)
			{
				writer.WriteStartObject();

				foreach (KeyValuePair<DateTime, TValue> kvp in dictionary)
				{
					writer.WritePropertyName(kvp.Key.ToString());

					if (_valueConverter != null)
					{
						_valueConverter.Write(writer, kvp.Value, options);
					}
					else
					{
						JsonSerializer.Serialize(writer, kvp.Value, options);
					}
				}

				writer.WriteEndObject();
			}
		}
	}
}
