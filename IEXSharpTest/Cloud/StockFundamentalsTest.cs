using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using IEXSharp;
using IEXSharp.Model.Shared.Request;
using IEXSharp.Model.StockFundamentals.Request;
using System;

namespace IEXSharpTest.Cloud
{
	public class StockFundamentalsTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.publishableToken, TestGlobal.secretToken, false, true);
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
		[TestCase("AAPL", DividendRange.OneMonth)]
		[TestCase("AAPL", DividendRange.OneYear)]
		[TestCase("AAPL", DividendRange.TwoYears)]
		[TestCase("AAPL", DividendRange.ThreeMonths)]
		[TestCase("AAPL", DividendRange.FiveYears)]
		[TestCase("AAPL", DividendRange.SixMonths)]
		[TestCase("AAPL", DividendRange.Next)]
		[TestCase("AMLP", DividendRange.Next)]
		[TestCase("AAPL", DividendRange.Ytd)]
		public async Task DividendsBasicAsyncTest(string symbol, DividendRange range)
		{
			var response = await sandBoxClient.StockFundamentals.DividendsBasicAsync(symbol, range);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[TestCase("ZIEXT", DividendRange.Next)]
		public async Task DividendsBasicAsyncWithUnknownSymbolTest(string symbol, DividendRange range)
		{
			var response = await sandBoxClient.StockFundamentals.DividendsBasicAsync(symbol, range);

			Assert.IsTrue(response.ErrorMessage.Equals("unknown symbol", StringComparison.InvariantCultureIgnoreCase));
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
		[TestCase("AAPL", SplitRange.OneMonth)]
		[TestCase("AAPL", SplitRange.OneYear)]
		[TestCase("AAPL", SplitRange.TwoYears)]
		[TestCase("AAPL", SplitRange.ThreeMonths)]
		[TestCase("AAPL", SplitRange.FiveYears)]
		[TestCase("AAPL", SplitRange.SixMonths)]
		[TestCase("AMLP", SplitRange.Next)]
		[TestCase("AAPL", SplitRange.Ytd)]
		public async Task SplitsBasicAsyncTest(string symbol, SplitRange range)
		{
			var response = await sandBoxClient.StockFundamentals.SplitsBasicAsync(symbol, range);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
		}

		[TestCase("ZIEXT", SplitRange.Next)]
		public async Task SplitsBasicAsyncUnkownSymbolTest(string symbol, SplitRange range)
		{
			var response = await sandBoxClient.StockFundamentals.SplitsBasicAsync(symbol, range);

			Assert.IsTrue(response.ErrorMessage.Equals("unknown symbol", StringComparison.InvariantCultureIgnoreCase));
		}
	}
}
