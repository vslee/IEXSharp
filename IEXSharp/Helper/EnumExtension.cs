using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace IEXSharp.Helper
{
	public static class EnumExtensions
	{
		public static string GetDescriptionFromEnum(this Enum enumValue)
		{
			string description = string.Empty;
			Type type = enumValue.GetType();
			MemberInfo[] memInfo = type.GetMember(enumValue.ToString());

			if (memInfo.First()
				.GetCustomAttributes(typeof(DescriptionAttribute), false)
				.FirstOrDefault() is DescriptionAttribute descriptionAttribute)
			{
				description = descriptionAttribute.Description;
			}

			return description;
		}

		public static TEnum GetEnumFromDescription<TEnum>(this string stringValue)
		{
			var enumType = typeof(TEnum);
			var members = enumType.GetMembers();
			foreach (var member in members)
			{
				var attr = member.GetCustomAttributes(typeof(DescriptionAttribute), false)
					.FirstOrDefault();
				if (attr is DescriptionAttribute descriptionAttribute
					&& descriptionAttribute.Description == stringValue)
				{
					return (TEnum)Enum.Parse(enumType, member.Name);
				}
			}
			throw new Exception("Description string not found.");
		}
	}
}