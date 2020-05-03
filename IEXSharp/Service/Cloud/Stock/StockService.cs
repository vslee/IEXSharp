using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.Shared.Response;
using VSLee.IEXSharp.Model.Stock.Request;
using VSLee.IEXSharp.Model.Stock.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;

namespace VSLee.IEXSharp.Service.Cloud.Stock
{
	internal class StockService : IStockService
	{
		private readonly ExecutorREST executor;

		public StockService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<BatchResponse>>
			BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types,
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

			return await executor.ExecuteAsync<BatchResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<Dictionary<string, BatchResponse>>> BatchByMarketAsync(IEnumerable<string> symbols,
			IEnumerable<BatchType> types, string range = "", int last = 1)
		{
			if (types?.Count() < 1)
			{
				throw new ArgumentNullException("batchTypes cannot be null");
			}
			else if (symbols?.Count() < 1)
			{
				throw new ArgumentNullException("symbols cannot be null");
			}

			const string urlPattern = "stock/market/batch";

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
			qsb.Add("symbols", string.Join(",", symbols));
			qsb.Add("types", string.Join(",", qsType));
			if (!string.IsNullOrWhiteSpace(range))
			{
				qsb.Add("range", range);
			}

			qsb.Add("last", last);

			var pathNvc = new NameValueCollection();

			return await executor.ExecuteAsync<Dictionary<string, BatchResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<Quote>>> CollectionsAsync(CollectionType collection, string collectionName)
		{
			const string urlPattern = "stock/market/collection/[collectionType]";

			var qsb = new QueryStringBuilder();
			qsb.Add("collectionName", collectionName);

			var pathNvc = new NameValueCollection { { "collectionType", collection.GetDescription() } };

			return await executor.ExecuteAsync<IEnumerable<Quote>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<EffectiveSpreadResponse>>> EffectiveSpreadAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<EffectiveSpreadResponse>>(
				"stock/[symbol]/effective-spread", symbol);

		public async Task<IEXResponse<IPOCalendar>> IPOCalendarAsync(IPOType ipoType)
		{
			const string urlPattern = "stock/market/[ipoType]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "ipoType", ipoType.GetDescription() } };

			return await executor.ExecuteAsync<IPOCalendar>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<Quote>>> ListAsync(string listType)
		{
			const string urlPattern = "stock/market/list/[list-type]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "list-type", listType } };

			return await executor.ExecuteAsync<IEnumerable<Quote>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<MarketVolumeUSResponse>>> MarketVolumeUSAsync() =>
			await executor.NoParamExecute<IEnumerable<MarketVolumeUSResponse>>("market");

		public async Task<IEXResponse<IEnumerable<NewsResponse>>> NewsAsync(string symbol, int last = 10) =>
			await executor.SymbolLastExecuteAsync<IEnumerable<NewsResponse>>("stock/[symbol]/news/last/[last]", symbol, last);

		public async Task<IEXResponse<IEnumerable<RecommendationTrendResponse>>> RecommendationTrendAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<RecommendationTrendResponse>>(
				"stock/[symbol]/recommendation-trends", symbol);

		public async Task<IEXResponse<IEnumerable<SectorPerformanceResponse>>> SectorPerformanceAsync() =>
			await executor.NoParamExecute<IEnumerable<SectorPerformanceResponse>>("stock/market/sector-performance");

		public async Task<IEXResponse<UpcomingEventSymbolResponse>> UpcomingEventSymbolAsync(string symbol, UpcomingEventType type)
		{
			const string urlPattern = "stock/[symbol]/upcoming-[type]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "type", type.GetDescription() } };

			return await executor.ExecuteAsync<UpcomingEventSymbolResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<UpcomingEventMarketResponse>> UpcomingEventMarketAsync(UpcomingEventType type)
		{
			const string urlPattern = "stock/market/upcoming-[type]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "type", type.GetDescription() } };

			return await executor.ExecuteAsync<UpcomingEventMarketResponse>(urlPattern, pathNvc, qsb);
		}
	}
}