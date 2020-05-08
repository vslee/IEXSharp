using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.InvestorsExchangeData.Response;
using IEXSharp.Model.MarketInfo.Request;
using IEXSharp.Model.MarketInfo.Response;
using IEXSharp.Model.Stock.Request;
using IEXSharp.Model.Stock.Response;
using IEXSharp.Model.StockFundamentals.Request;
using IEXSharp.Model.StockFundamentals.Response;
using IEXSharp.Model.StockPrices.Response;
using IEXSharp.Model.StockProfiles.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXSharp.Service.Legacy.Stock
{
	internal class StockService : IStockService
	{
		private readonly ExecutorREST _executor;

		public StockService(HttpClient client)
		{
			_executor = new ExecutorREST(client, string.Empty, string.Empty, false);
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

			return await _executor.ExecuteAsync<BatchBySymbolLegacyResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<BookResponse>> BookAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<BookResponse>("stock/[symbol]/book", symbol);

		public async Task<IEXResponse<IEnumerable<DividendV1Response>>> DividendAsync(string symbol, DividendRange range)
		{
			const string urlPattern = "stock/[symbol]/dividends/[range]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol}, {"range", range.GetDescriptionFromEnum()}
			};

			return await _executor.ExecuteAsync<IEnumerable<DividendV1Response>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<EffectiveSpreadResponse>>> EffectiveSpreadAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<IEnumerable<EffectiveSpreadResponse>>(
				"stock/[symbol]/effective-spread", symbol);

		public async Task<IEXResponse<IPOCalendarResponse>> IPOCalendarAsync(IPOType ipoType)
		{
			const string urlPattern = "stock/market/[ipoType]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "ipoType", ipoType.GetDescriptionFromEnum() } };

			return await _executor.ExecuteAsync<IPOCalendarResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>>> ListedRegulationSHOThresholdSecuritiesListAsync(string symbol)
			=> await _executor.SymbolExecuteAsync<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>>(
				"stock/[symbol]/threshold-securities", symbol);

		public async Task<IEXResponse<IEnumerable<ListedShortInterestListResponse>>> ListedShortInterestListAsync(string symbol)
			=> await _executor.SymbolExecuteAsync<IEnumerable<ListedShortInterestListResponse>>(
				"stock/[symbol]/short-interest", symbol);

		public async Task<IEXResponse<LogoResponse>> LogoAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<LogoResponse>("stock/[symbol]/logo", symbol);

		public async Task<IEXResponse<OHLCResponse>> OHLCAsync(string symbol) =>
			await _executor.SymbolExecuteAsync<OHLCResponse>("stock/[symbol]/ohlc", symbol);
	}
}