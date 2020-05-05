using IEXSharp.Helper;
using IEXSharp.Model;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Model.MarketInfo.Request;
using IEXSharp.Model.MarketInfo.Response;
using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.MarketInfo.Request;
using VSLee.IEXSharp.Model.MarketInfo.Response;
using VSLee.IEXSharp.Model.Shared.Response;
using VSLee.IEXSharp.Model.StockFundamentals.Response;

namespace IEXSharp.Service.Cloud.MarketInfo
{
	public class MarketInfoService : IMarketInfoService
	{
		private readonly ExecutorREST executor;

		public MarketInfoService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<IEnumerable<Quote>>> CollectionsAsync(CollectionType collection,
			string collectionName)
		{
			const string urlPattern = "stock/market/collection/[collectionType]";
			var qsb = new QueryStringBuilder();
			qsb.Add("collectionName", collectionName);
			var pathNvc = new NameValueCollection {{"collectionType", collection.GetDescription()}};

			return await executor.ExecuteAsync<IEnumerable<Quote>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<EarningTodayResponse>> EarningsTodayAsync() =>
			await executor.NoParamExecute<EarningTodayResponse>("stock/market/today-earnings");

		public async Task<IEXResponse<IPOCalendarResponse>> IPOCalendarAsync(IPOType ipoType) =>
			await executor.NoParamExecute<IPOCalendarResponse>($"stock/market/{ipoType.GetDescription()}");

		public async Task<IEXResponse<IEnumerable<Quote>>> ListAsync(ListType listType) =>
			await executor.NoParamExecute<IEnumerable<Quote>>($"stock/market/list/{listType.GetDescription()}");

		public async Task<IEXResponse<IEnumerable<MarketVolumeUSResponse>>> MarketVolumeUSAsync() =>
			await executor.NoParamExecute<IEnumerable<MarketVolumeUSResponse>>("stock/market/volume");

		public async Task<IEXResponse<IEnumerable<SectorPerformanceResponse>>> SectorPerformanceAsync() =>
			await executor.NoParamExecute<IEnumerable<SectorPerformanceResponse>>("stock/market/sector-performance");

		public async Task<IEXResponse<UpcomingEventSymbolResponse>> UpcomingEventSymbolAsync(string symbol,
			UpcomingEventType type)
		{
			const string urlPattern = "stock/[symbol]/upcoming-[type]";
			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection {{"symbol", symbol}, {"type", type.GetDescription()}};

			return await executor.ExecuteAsync<UpcomingEventSymbolResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<UpcomingEventMarketResponse>>> UpcomingEventMarketAsync(
			UpcomingEventType type)
		{
			const string urlPattern = "stock/market/upcoming-[type]";
			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection {{"type", type.GetDescription()}};

			return await executor.ExecuteAsync<IEnumerable<UpcomingEventMarketResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<UpcomingEventMarketResponse>> UpcomingEventsAsync(string symbol)
		{
			string urlPattern = "stock/[symbol]/upcoming-[type]";
			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection {{"type", UpcomingEventType.Events.GetDescription()}};

			if (string.IsNullOrEmpty(symbol))
			{
				urlPattern = urlPattern.Replace("[symbol]", "market");
			}
			else
			{
				pathNvc.Add("symbol", symbol);
			}

			return await executor.ExecuteAsync<UpcomingEventMarketResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<UpcomingEarningsResponse>>> UpcomingEarningsAsync(string symbol)
		{
			string urlPattern = "stock/[symbol]/upcoming-[type]";
			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection {{"type", UpcomingEventType.Earnings.GetDescription()}};

			if (string.IsNullOrEmpty(symbol))
			{
				urlPattern = urlPattern.Replace("[symbol]", "market");
			}
			else
			{
				pathNvc.Add("symbol", symbol);
			}

			return await executor.ExecuteAsync<IEnumerable<UpcomingEarningsResponse>>(urlPattern, pathNvc, qsb);
		}
	}
}
