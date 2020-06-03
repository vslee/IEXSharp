using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.StockPrices.Request;
using IEXSharp.Model.CoreData.StockPrices.Response;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Service.Cloud.CoreData.StockPrices
{
	public class StockPricesService : IStockPricesService
	{
		private readonly ExecutorREST executor;
		private readonly ExecutorSSE executorSSE;

		internal StockPricesService(ExecutorREST executor, ExecutorSSE executorSSE)
		{
			this.executor = executor;
			this.executorSSE = executorSSE;
		}

		public async Task<IEXResponse<BookResponse>> BookAsync(string symbol) =>
			await executor.SymbolExecuteAsync<BookResponse>("stock/[symbol]/book", symbol);

		public async Task<IEXResponse<DelayedQuoteResponse>> DelayedQuoteAsync(string symbol) =>
			await executor.SymbolExecuteAsync<DelayedQuoteResponse>("stock/[symbol]/delayed-quote", symbol);

		public async Task<IEXResponse<IEnumerable<HistoricalPriceResponse>>> HistoricalPriceAsync(string symbol,
			ChartRange range = ChartRange.OneMonth, QueryStringBuilder qsb = null)
		{
			const string urlPattern = "stock/[symbol]/chart/[range]";

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol},
				{"range", range.GetDescriptionFromEnum()},
			};

			return await executor.ExecuteAsync<IEnumerable<HistoricalPriceResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<HistoricalPriceResponse>>> HistoricalPriceByDateAsync(string symbol,
			DateTime date, bool chartByDay, QueryStringBuilder qsb = null)
		{
			const string urlPattern = "stock/[symbol]/chart/date/[date]";

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol},
				{"date", date == null ? DateTime.Now.ToString("yyyyMMdd") : date.ToString("yyyyMMdd")}
			};

			qsb = qsb ?? new QueryStringBuilder();
			if (chartByDay)
				qsb.Add("chartByDay", "true");

			return await executor.ExecuteAsync<IEnumerable<HistoricalPriceResponse>>(urlPattern, pathNvc, qsb: qsb);
		}

		public async Task<IEXResponse<HistoricalPriceDynamicResponse>> HistoricalPriceDynamicAsync(string symbol,
			QueryStringBuilder qsb = null)
		{
			const string urlPattern = "stock/[symbol]/chart/dynamic";

			qsb = qsb ?? new QueryStringBuilder();

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol}
			};

			return await executor.ExecuteAsync<HistoricalPriceDynamicResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<IntradayPriceResponse>>> IntradayPricesAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<IntradayPriceResponse>>("stock/[symbol]/intraday-prices", symbol);

		public async Task<IEXResponse<IEnumerable<LargestTradeResponse>>> LargestTradesAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<LargestTradeResponse>>("stock/[symbol]/largest-trades", symbol);

		public async Task<IEXResponse<OHLCResponse>> OHLCAsync(string symbol) =>
			await executor.SymbolExecuteAsync<OHLCResponse>("stock/[symbol]/ohlc", symbol);

		public async Task<IEXResponse<HistoricalPriceResponse>> PreviousDayPriceAsync(string symbol) =>
			await executor.SymbolExecuteAsync<HistoricalPriceResponse>("stock/[symbol]/previous", symbol);

		public async Task<IEXResponse<decimal>> PriceAsync(string symbol)
		{
			var returnValue = await executor.SymbolExecuteAsync<string>("stock/[symbol]/price", symbol);
			if (returnValue.ErrorMessage != null)
				return new IEXResponse<decimal>() { ErrorMessage = returnValue.ErrorMessage };
			else
				return new IEXResponse<decimal>() { Data = decimal.Parse(returnValue.Data) };
		}

		public async Task<IEXResponse<Quote>> QuoteAsync(string symbol) =>
			await executor.SymbolExecuteAsync<Quote>("stock/[symbol]/quote", symbol);

		public async Task<IEXResponse<string>> QuoteFieldAsync(string symbol, string field)
		{
			const string urlPattern = "stock/[symbol]/quote/[field]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "field", field } };

			return await executor.ExecuteAsync<string>(urlPattern, pathNvc, qsb);
		}

		public SSEClient<QuoteSSE> QuoteStream(
			IEnumerable<string> symbols, bool UTP, StockQuoteSSEInterval interval) =>
			executorSSE.SymbolsSubscribeSSE<QuoteSSE>(
				UTP ? $"stocksUS{interval.GetDescriptionFromEnum()}" : $"stocksUSNoUTP{interval.GetDescriptionFromEnum()}", symbols);

		public async Task<IEXResponse<IEnumerable<VolumeByVenueResponse>>> VolumeByVenueAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<VolumeByVenueResponse>>("stock/[symbol]/volume-by-venue", symbol);
	}
}
