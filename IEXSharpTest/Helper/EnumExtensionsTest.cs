using System;
using IEXSharp.Helper;
using IEXSharp.Model.Batch.Request;
using IEXSharp.Model.CorporateActions.Request;
using IEXSharp.Model.StockPrices.Request;
using NUnit.Framework;

namespace IEXSharpTest.Helper
{
	public class EnumExtensionsTest
	{
		[Test]
		[TestCase(TimeSeriesRange.Today, "today")]
		[TestCase(TimeSeriesRange.ThisQuarter, "this-quarter")]
		public void GetDescriptionFromEnumTest(Enum inputEnum, string expected)
		{
			var result = inputEnum.GetDescriptionFromEnum();

			Assert.AreEqual(expected, result);
		}

		[Test]
		[TestCase("today", TimeSeriesRange.Today)]
		[TestCase("this-quarter", TimeSeriesRange.ThisQuarter)]
		public void GetTimeSeriesRangeFromDescriptionTest(string input, Enum expected)
		{
			var result = input.GetEnumFromDescription<TimeSeriesRange>();
			Assert.AreEqual(expected, result);
		}

		[Test]
		[TestCase("date", ChartRange.Date)]
		[TestCase("1m", ChartRange.OneMonth)]
		public void GetChartRangeFromDescriptionTest(string input, Enum expected)
		{
			var result = input.GetEnumFromDescription<ChartRange>();
			Assert.AreEqual(expected, result);
		}

		[Test]
		[TestCase("advanced-stats", BatchType.AdvancedStats)]
		[TestCase("balance-sheet", BatchType.BalanceSheets)]
		public void GetBatchTypeFromDescriptionTest(string input, Enum expected)
		{
			var result = input.GetEnumFromDescription<BatchType>();
			Assert.AreEqual(expected, result);
		}

		[Test]
		[TestCase("gibberish")]
		public void GetEnumFromDescriptionFailure(string input)
		{
			Assert.Throws<Exception>(code: () => input.GetEnumFromDescription<BatchType>());
		}
	}
}