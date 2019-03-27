using IEX.V2.Model.Stock.Request;
using IEX.V2.Model.Stock.Response;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEX.Test
{
    public class StockTest
    {
        private IEX.V2.IEXClient sandBoxClient;
        private IEX.V2.IEXClient prodClient;

        [SetUp]
        public void Setup()
        {
            sandBoxClient = new IEX.V2.IEXClient("Tpk_d1e87a5a345b434d8f151269fb62071b",
                "Tsk_73e92cf1e5b1432699f90a17c25f0f88", true);
            prodClient = new IEX.V2.IEXClient("pk_7c46062bc0aa4a8698a550dcbd788e3c",
                "sk_45d242d9d05a4f238082d6113c49529f", false);
        }

        [Test]
        [TestCase("aapl", Period.Quarter)]
        [TestCase("aapl", Period.Annual)]
        public void BalanceSheetTest(string symbol, Period period)
        {
            BalanceSheetResponse response = sandBoxClient.Stock.BalanceSheet(symbol, period);

            Assert.IsNotNull(response);
            Assert.GreaterOrEqual(response.balancesheet.Count, 1);
        }

        [Test]
        [TestCase("aapl", Period.Quarter)]
        [TestCase("aapl", Period.Annual)]
        public async Task BalanceSheetAsyncTest(string symbol, Period period)
        {
            BalanceSheetResponse response = await sandBoxClient.Stock.BalanceSheetAsync(symbol, period);

            Assert.IsNotNull(response);
            Assert.GreaterOrEqual(response.balancesheet.Count, 1);
        }

        [Test]
        [TestCase("aapl", Period.Quarter, "currentCash", 1)]
        [TestCase("aapl", Period.Quarter, "currentCash", 2)]
        public void BalanceSheetFieldTest(string symbol, Period period, string field, int last)
        {
            object response = sandBoxClient.Stock.BalanceSheetField(symbol, period, field, last);

            Assert.IsTrue(long.TryParse(response.ToString(), out long test));
        }

        [Test]
        [TestCase("aapl", Period.Quarter, 1, "currentCash")]
        [TestCase("aapl", Period.Quarter, 2, "currentCash")]
        public async Task BalanceSheetFieldAsyncTest(string symbol, Period period, int last, string field)
        {
            object response = await sandBoxClient.Stock.BalanceSheetFieldAsync(symbol, period, field, last);

            Assert.IsTrue(long.TryParse(response.ToString(), out long test));
        }

        [Test]
        [TestCase("aapl", new BatchType[] { BatchType.Quote, BatchType.News })]
        [TestCase("aapl", new BatchType[] { BatchType.Quote }, "1m")]
        [TestCase("aapl", new BatchType[] { BatchType.Quote }, "1m", 2)]
        public void BatchBySymbolTest(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1)
        {
            BatchBySymbolResponse response = sandBoxClient.Stock.BatchBySymbol(symbol, types, range, last);

            Assert.IsNotNull(response);
        }

        [Test]
        [TestCase("aapl", new BatchType[] { BatchType.Quote, BatchType.News })]
        [TestCase("aapl", new BatchType[] { BatchType.Quote }, "1m")]
        [TestCase("aapl", new BatchType[] { BatchType.Quote }, "1m", 2)]
        public void BatchBySymbolAsyncTest(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1)
        {
            BatchBySymbolResponse response = sandBoxClient.Stock.BatchBySymbol(symbol, types, range, last);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.quote);
        }

        [Test]
        [TestCase(new string[] { "aapl", "fb" }, new BatchType[] { BatchType.Quote, BatchType.News })]
        [TestCase(new string[] { "aapl", "fb" }, new BatchType[] { BatchType.Quote}, "1m")]
        [TestCase(new string[] { "aapl", "fb" }, new BatchType[] { BatchType.Quote}, "1m", 2)]
        public void BatchByMarketTest(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1)
        {
            Dictionary<string, BatchBySymbolResponse> response = sandBoxClient.Stock.BatchByMarket(symbols, types, range, last);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response["AAPL"]);
            Assert.IsNotNull(response["FB"]);
            Assert.IsNotNull(response["AAPL"].quote);
            Assert.IsNotNull(response["FB"].quote);
        }

        [Test]
        [TestCase(new string[] { "aapl", "fb" }, new BatchType[] { BatchType.Quote, BatchType.News }, "1m", 2)]
        public async Task BatchByMarketAsyncTest(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1)
        {
            Dictionary<string, BatchBySymbolResponse> response = await sandBoxClient.Stock.BatchByMarketAsync(symbols, types, range, last);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response["AAPL"]);
            Assert.IsNotNull(response["FB"]);
            Assert.IsNotNull(response["AAPL"].quote);
            Assert.IsNotNull(response["FB"].quote);
        }

        [Test]
        [TestCase("aapl")]
        public void BookTest(string symbol)
        {
            BookResponse response = sandBoxClient.Stock.Book(symbol);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.quote);
            Assert.IsEmpty(response.bids);
            Assert.IsEmpty(response.asks);
            Assert.IsNotNull(response.trades);
            Assert.IsNotNull(response.systemEvent);
        }

        [Test]
        [TestCase("aapl")]
        public async Task BookAsyncTest(string symbol)
        {
            BookResponse response = await sandBoxClient.Stock.BookAsync(symbol);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.quote);
            Assert.IsEmpty(response.bids);
            Assert.IsEmpty(response.asks);
            Assert.IsNotNull(response.trades);
            Assert.IsNotNull(response.systemEvent);
        }

        [Test]
        [TestCase("aapl", Period.Quarter)]
        [TestCase("aapl", Period.Annual)]
        public void CashFlowTest(string symbol, Period period)
        {
            CashFlowResponse response = sandBoxClient.Stock.CashFlow(symbol, period);

            Assert.IsNotNull(response);
            Assert.GreaterOrEqual(response.cashflow.Count, 1);
        }

        [Test]
        [TestCase("aapl", Period.Quarter)]
        [TestCase("aapl", Period.Annual)]
        public async Task CashFlowAsyncTest(string symbol, Period period)
        {
            CashFlowResponse response = await sandBoxClient.Stock.CashFlowAsync(symbol, period);

            Assert.IsNotNull(response);
            Assert.GreaterOrEqual(response.cashflow.Count, 1);
        }

        [Test]
        [TestCase("aapl", Period.Quarter, "cashChange", 1)]
        [TestCase("aapl", Period.Quarter, "cashChange", 2)]
        public void CashFlowFieldTest(string symbol, Period period, string field, int last)
        {
            object response = sandBoxClient.Stock.CashFlowField(symbol, period, field, last);

            Assert.IsTrue(long.TryParse(response.ToString(), out long test));
        }

        [Test]
        [TestCase("aapl", Period.Quarter, "cashChange", 1)]
        [TestCase("aapl", Period.Quarter, "cashChange", 2)]
        public async Task CashFlowFieldAsyncTest(string symbol, Period period, string field, int last)
        {
            object response = await sandBoxClient.Stock.CashFlowFieldAsync(symbol, period, field, last);

            Assert.IsTrue(long.TryParse(response.ToString(), out long test));
        }
    }
}