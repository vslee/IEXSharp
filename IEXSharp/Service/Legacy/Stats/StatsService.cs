using IEXSharp.Helper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.InvestorsExchangeData.Response;

namespace IEXSharp.Service.Legacy.Stats
{
	internal class StatsService : IStatsService
	{
		private readonly ExecutorREST executor;

		internal StatsService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<StatsIntradayResponse>> StatsIntradayAsync() =>
			await executor.NoParamExecute<StatsIntradayResponse>("stats/intraday");

		public async Task<IEXResponse<IEnumerable<StatsRecentResponse>>> StatsRecentAsync() =>
			await executor.NoParamExecute<IEnumerable<StatsRecentResponse>>("stats/recent");

		public async Task<IEXResponse<StatsRecordResponse>> StatsRecordAsync() =>
			await executor.NoParamExecute<StatsRecordResponse>("stats/records");

		public async Task<IEXResponse<IEnumerable<StatsHistoricalSummaryResponse>>> StatsHistoricalSummaryAsync(DateTime? date = null)
		{
			const string urlPattern = "stats/historical";
			var qsb = new QueryStringBuilder();
			qsb.Add("date", date == null ? DateTime.Now.ToString("yyyyMM") : ((DateTime)date).ToString("yyyyMM"));
			var pathNvc = new NameValueCollection();

			return await executor.ExecuteAsync<IEnumerable<StatsHistoricalSummaryResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<StatsHisoricalDailyResponse>>> StatsHistoricalDailyByDateAsync(string date)
		{
			const string urlPattern = "stats/historical/daily";
			var qsb = new QueryStringBuilder();
			qsb.Add("date", date);
			var pathNvc = new NameValueCollection();

			return await executor.ExecuteAsync<IEnumerable<StatsHisoricalDailyResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<StatsHisoricalDailyResponse>>> StatsHistoricalDailyByLastAsync(int last)
		{
			const string urlPattern = "stats/historical/daily";
			var qsb = new QueryStringBuilder();
			qsb.Add("last", last);
			var pathNvc = new NameValueCollection();

			return await executor.ExecuteAsync<IEnumerable<StatsHisoricalDailyResponse>>(urlPattern, pathNvc, qsb);
		}
	}
}