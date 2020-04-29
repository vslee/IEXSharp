using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace IEXSharp.Helper
{
	public static class EnumExtension
	{
		public static string GetDescription(this Enum enumValue)
		{
			string description = string.Empty;
			Type type = enumValue.GetType();
			MemberInfo[] memInfo = type.GetMember(enumValue.ToString());

			if (memInfo[0]
				.GetCustomAttributes(typeof(DescriptionAttribute), false)
				.FirstOrDefault() is DescriptionAttribute descriptionAttribute)
			{
				description = descriptionAttribute.Description;
			}

			return description;
		}
	}
}