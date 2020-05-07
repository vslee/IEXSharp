using System;
using IEXSharp.Helper;
using IEXSharp.Model.CorporateActions.Request;
using IEXSharp.Model.Stock.Request;
using IEXSharp.Model.StockPrices.Request;
using NUnit.Framework;

namespace IEXSharpTest.Helper
{
	public class StringExtensionsTest
	{
		[Test]
		[TestCase("today", TimeSeriesRange.Today)]
		[TestCase("this-quarter", TimeSeriesRange.ThisQuarter)]
		public void GetTimeSeriesRangeTest(string input, Enum expected)
		{
			var result = input.GetEnumFromDescription<TimeSeriesRange>();
			Assert.AreEqual(expected, result);
		}

		[Test]
		[TestCase("date", ChartRange.Date)]
		[TestCase("1m", ChartRange.OneMonth)]
		public void GetChartRangeTest(string input, Enum expected)
		{
			var result = input.GetEnumFromDescription<ChartRange>();
			Assert.AreEqual(expected, result);
		}

		[Test]
		[TestCase("advanced-stats", BatchType.AdvancedStats)]
		[TestCase("balance-sheet", BatchType.BalanceSheets)]
		public void GetBatchTypeTest(string input, Enum expected)
		{
			var result = input.GetEnumFromDescription<BatchType>();
			Assert.AreEqual(expected, result);
		}
	}
}
