using System;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model.CorporateActions.Request;
using NUnit.Framework;

namespace IEXSharpTest.Helper
{
	public class EnumExtensionsTest
	{
		[Test]
		[TestCase(TimeSeriesRange.Today, "today")]
		[TestCase(TimeSeriesRange.ThisQuarter, "this-quarter")]
		public async Task GetDescriptionTest(Enum inputEnum, string expected)
		{
			var result = inputEnum.GetDescription();

			Assert.AreEqual(expected, result);
		}
	}
}