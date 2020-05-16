using IEXSharp.Helper;
using IEXSharp.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Model.CoreData.Batch.Request;
using IEXSharp.Model.CoreData.Batch.Response;
using IEXSharp.Model.CoreData.MarketInfo.Request;
using IEXSharp.Model.CoreData.MarketInfo.Response;
using IEXSharp.Model.CoreData.Stock.Response;
using IEXSharp.Model.CoreData.StockFundamentals.Request;
using IEXSharp.Model.CoreData.StockFundamentals.Response;
using IEXSharp.Model.CoreData.StockPrices.Response;
using IEXSharp.Model.CoreData.StockProfiles.Response;

namespace IEXSharp.Service.Legacy.Stock
{
	internal class StockService : IStockService
	{
		private readonly ExecutorREST executor;

		internal StockService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<BatchBySymbolLegacyResponse>> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types,
			string range = "", int last = 1)
		{
			if (types?.Count() < 1)
			{
				throw new ArgumentNullException(nameof(types));
			}

			const string urlPattern = "stock/[symbol]/batch";

			var qsType = new List<string>();
			foreach (var x in types)
			{
				switch (x)
				{
					case BatchType.Quote:
						qsType.Add("quote");
						break;

					case BatchType.News:
						qsType.Add("news");
						break;

					case BatchType.Chart:
						qsType.Add("chart");
						break;

					default:
						throw new ArgumentOutOfRangeException(nameof(types));
				}
			}

			var qsb = new QueryStringBuilder();

			qsb.Add("types", string.Join(",", qsType));
			if (!string.IsNullOrWhiteSpace(range))
			{
				qsb.Add("range", range);
			}

			qsb.Add("last", last);

			var pathNvc = new NameValueCollection { { "symbol", symbol } };

			return await executor.ExecuteAsync<BatchBySymbolLegacyResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<BookResponse>> BookAsync(string symbol) =>
			await executor.SymbolExecuteAsync<BookResponse>("stock/[symbol]/book", symbol);

		public async Task<IEXResponse<IEnumerable<DividendV1Response>>> DividendAsync(string symbol, DividendRange range)
		{
			const string urlPattern = "stock/[symbol]/dividends/[range]";
			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol}, {"range", range.GetDescriptionFromEnum()}
			};

			return await executor.ExecuteAsync<IEnumerable<DividendV1Response>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<EffectiveSpreadResponse>>> EffectiveSpreadAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<EffectiveSpreadResponse>>(
				"stock/[symbol]/effective-spread", symbol);

		public async Task<IEXResponse<IPOCalendarResponse>> IPOCalendarAsync(IPOType ipoType)
		{
			const string urlPattern = "stock/market/[ipoType]";
			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "ipoType", ipoType.GetDescriptionFromEnum() } };

			return await executor.ExecuteAsync<IPOCalendarResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<LogoResponse>> LogoAsync(string symbol) =>
			await executor.SymbolExecuteAsync<LogoResponse>("stock/[symbol]/logo", symbol);

		public async Task<IEXResponse<OHLCResponse>> OHLCAsync(string symbol) =>
			await executor.SymbolExecuteAsync<OHLCResponse>("stock/[symbol]/ohlc", symbol);
	}
}