using IEXSharp.Helper;
using IEXSharp.Model;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.MarketInfo.Request;
using VSLee.IEXSharp.Model.MarketInfo.Response;
using VSLee.IEXSharp.Model.Shared.Response;

namespace IEXSharp.Service.Cloud.MarketInfo
{
	public class MarketInfoService : IMarketInfoService
	{
		private readonly ExecutorREST executor;

		public MarketInfoService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<IEnumerable<Quote>>> CollectionsAsync(CollectionType collection, string collectionName)
		{
			const string urlPattern = "stock/market/collection/[collectionType]";
			var qsb = new QueryStringBuilder();
			qsb.Add("collectionName", collectionName);
			var pathNvc = new NameValueCollection { { "collectionType", collection.GetDescription() } };

			return await executor.ExecuteAsync<IEnumerable<Quote>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IPOCalendarResponse>> IPOCalendarAsync(IPOType ipoType)
		{
			const string urlPattern = "stock/market/[ipoType]";
			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "ipoType", ipoType.GetDescription() } };

			return await executor.ExecuteAsync<IPOCalendarResponse>(urlPattern, pathNvc, qsb);
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

		public async Task<IEXResponse<IEnumerable<SectorPerformanceResponse>>> SectorPerformanceAsync() =>
			await executor.NoParamExecute<IEnumerable<SectorPerformanceResponse>>("stock/market/sector-performance");

		public async Task<IEXResponse<UpcomingEventSymbolResponse>> UpcomingEventSymbolAsync(string symbol, UpcomingEventType type)
		{
			const string urlPattern = "stock/[symbol]/upcoming-[type]";
			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "type", type.GetDescription() } };

			return await executor.ExecuteAsync<UpcomingEventSymbolResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<UpcomingEventMarketResponse>>> UpcomingEventMarketAsync(UpcomingEventType type)
		{
			const string urlPattern = "stock/market/upcoming-[type]";
			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "type", type.GetDescription() } };

			return await executor.ExecuteAsync<IEnumerable<UpcomingEventMarketResponse>>(urlPattern, pathNvc, qsb);
		}
	}
}
