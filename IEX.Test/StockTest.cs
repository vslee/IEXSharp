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

        [SetUp]
        public void Setup()
        {
            sandBoxClient = new IEX.V2.IEXClient("", "", true);
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
        [TestCase("aapl", Period.Quarter, 1, "currentCash")]
        [TestCase("aapl", Period.Quarter, 2, "currentCash")]
        public async Task BalanceSheetFieldAsyncTest(string symbol, Period period, int last, string field)
        {
            object response = await sandBoxClient.Stock.BalanceSheetFieldAsync(symbol, period, field, last);

            Assert.IsTrue(long.TryParse(response.ToString(), out long test));
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
        [TestCase("aapl", Period.Quarter, "cashChange", 1)]
        [TestCase("aapl", Period.Quarter, "cashChange", 2)]
        public async Task CashFlowFieldAsyncTest(string symbol, Period period, string field, int last)
        {
            object response = await sandBoxClient.Stock.CashFlowFieldAsync(symbol, period, field, last);

            Assert.IsTrue(long.TryParse(response.ToString(), out long test));
        }
    }
}