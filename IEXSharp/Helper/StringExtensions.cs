using System;
using System.ComponentModel;
using System.Linq;

namespace IEXSharp.Helper
{
	public static class StringExtensions
	{
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
