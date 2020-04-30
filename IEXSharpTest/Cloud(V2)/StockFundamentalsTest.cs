using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSLee.IEXSharp;
using VSLee.IEXSharp.Model.StockFundamentals.Request;
using VSLee.IEXSharpTest.Cloud;

namespace IEXSharpTest.Cloud_V2_
{
	public class StockFundamentalsTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(publishableToken: TestGlobal.pk, secretToken: TestGlobal.sk, signRequest: false, useSandBox: true);
		}

		[Test]
		[TestCase("AAPL", Period.Quarter, 1)]
		[TestCase("FB", Period.Quarter, 2)]
		public async Task BalanceSheetAsyncTest(string symbol, Period period = Period.Quarter,
			int last = 1)
		{
			var response = await sandBoxClient.StockFundamentals.BalanceSheetAsync(symbol, period, last);
			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.balancesheet);
			Assert.GreaterOrEqual(response.Data.balancesheet.Count, 1);
		}

		[Test]
		[TestCase("AAPL", "currentCash", Period.Quarter, 1)]
		[TestCase("FB", "currentCash", Period.Quarter, 2)]
		public async Task BalanceSheetFieldAsyncTest(string symbol, string field, Period period = Period.Quarter, int last = 1)
		{
			var response = await sandBoxClient.StockFundamentals.BalanceSheetFieldAsync(symbol, field, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", Period.Quarter, 1)]
		[TestCase("AAPL", Period.Annual, 2)]
		public async Task CashFlowAsyncTest(string symbol, Period period = Period.Quarter, int last = 1)
		{
			var response = await sandBoxClient.StockFundamentals.CashFlowAsync(symbol, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "reportDate", Period.Annual, 1)]
		[TestCase("AAPL", "reportDate", Period.Quarter, 2)]
		public async Task CashFlowFieldAsyncTest(string symbol, string field, Period period = Period.Quarter, int last = 1)
		{
			var response = await sandBoxClient.StockFundamentals.CashFlowFieldAsync(symbol, field, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", DividendRange._1m)]
		[TestCase("AAPL", DividendRange._1y)]
		[TestCase("AAPL", DividendRange._2y)]
		[TestCase("AAPL", DividendRange._3m)]
		[TestCase("AAPL", DividendRange._5y)]
		[TestCase("AAPL", DividendRange._6m)]
		[TestCase("AAPL", DividendRange._next)]
		[TestCase("AAPL", DividendRange._ytd)]
		public async Task DividendAsyncTest(string symbol, DividendRange range)
		{
			var response = await sandBoxClient.StockFundamentals.DividendAsync(symbol, range);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		public async Task EarningTodayAsyncTest()
		{
			var response = await sandBoxClient.StockFundamentals.EarningTodayAsync();

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", 1)]
		[TestCase("FB", 2)]
		public async Task EarningAsyncTest(string symbol, int last)
		{
			var response = await sandBoxClient.StockFundamentals.EarningAsync(symbol, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "consensusEPS", 1)]
		[TestCase("AAPL", "announceTime", 2)]
		public async Task EarningFieldAsyncTest(string symbol, string field, int last)
		{
			var response = await sandBoxClient.StockFundamentals.EarningFieldAsync(symbol, field, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", 1)]
		[TestCase("FB", 2)]
		public async Task FinancialAsyncTest(string symbol, int last)
		{
			var response = await sandBoxClient.StockFundamentals.FinancialAsync(symbol, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.financials.Count, 1);
		}

		[Test]
		[TestCase("AAPL", "grossProfit", 1)]
		[TestCase("FB", "grossProfit", 2)]
		public async Task FinancialFieldAsyncTest(string symbol, string field, int last)
		{
			var response = await sandBoxClient.StockFundamentals.FinancialFieldAsync(symbol, field, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[Test]
		[TestCase("AAPL", "costOfRevenue", Period.Quarter, 1)]
		[TestCase("AAPL", "costOfRevenue", Period.Annual, 2)]
		public async Task IncomeStatementFieldAsyncTest(string symbol, string field, Period period = Period.Quarter, int last = 1)
		{
			var response = await sandBoxClient.StockFundamentals.IncomeStatementFieldAsync(symbol, field, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}
		[Test]
		[TestCase("AAPL", Period.Annual, 1)]
		[TestCase("FB", Period.Quarter, 2)]
		public async Task IncomeStatementAsyncTest(string symbol, Period period, int last)
		{
			var response = await sandBoxClient.StockFundamentals.IncomeStatementAsync(symbol, period, last);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.income);
			Assert.AreEqual(last, response.Data.income.Count);
		}

		[Test]
		[TestCase("AAPL")]
		[TestCase("FB")]
		public async Task GivenAnnualPeriod_IncomeStatementAsync_ShouldReturnOneStatementPerYear(string symbol)
		{
			const Period period = Period.Annual;
			const int upToXStatements = 2;

			var response = await sandBoxClient.StockFundamentals.IncomeStatementAsync(symbol, period, upToXStatements);

			var firstStatementReportYear = response.Data.income.ElementAt(0).reportDate.Substring(0, 4);
			var secondStatementReportYear = response.Data.income.ElementAt(1).reportDate.Substring(0, 4);

			Assert.That(firstStatementReportYear != secondStatementReportYear);
		}


		[Test]
		[TestCase("AAPL", SplitRange._1m)]
		[TestCase("AAPL", SplitRange._1y)]
		[TestCase("AAPL", SplitRange._2y)]
		[TestCase("AAPL", SplitRange._3m)]
		[TestCase("AAPL", SplitRange._5y)]
		[TestCase("AAPL", SplitRange._6m)]
		[TestCase("AAPL", SplitRange._next)]
		[TestCase("AAPL", SplitRange._ytd)]
		public async Task SplitAsyncTest(string symbol, SplitRange range)
		{
			var response = await sandBoxClient.StockFundamentals.SplitAsync(symbol, range);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.GreaterOrEqual(response.Data.Count(), 1);
		}
	}
}
