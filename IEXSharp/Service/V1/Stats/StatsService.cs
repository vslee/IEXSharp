using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.InvestorsExchangeData.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace VSLee.IEXSharp.Service.V1.Stats
{
	internal class StatsService : IStatsService
	{
		private ExecutorREST _executor;

		public StatsService(HttpClient client)
		{
			_executor = new ExecutorREST(client, "", "", false);
		}

		public async Task<StatsIntradayResponse> StatsIntradayAsync()
			=> await _executor.NoParamExecute<StatsIntradayResponse>("stats/intraday", "");

		public async Task<IEnumerable<StatsRecentResponse>> StatsRecentAsync()
			=> await _executor.NoParamExecute<IEnumerable<StatsRecentResponse>>("stats/recent", "");

		public async Task<StatsRecordResponse> StatsRecordAsync()
			=> await _executor.NoParamExecute<StatsRecordResponse>("stats/records", "");

		public async Task<IEnumerable<StatsHistoricalSummaryResponse>> StatsHistoricalSummaryAsync(DateTime? date = null)
		{
			const string urlPattern = "stats/historical";

			var qsb = new QueryStringBuilder();
			qsb.Add("date", date == null ? DateTime.Now.ToString("yyyyMM") : ((DateTime)date).ToString("yyyyMM"));

			var pathNvc = new NameValueCollection();

			return await _executor.ExecuteAsyncLegacy<IEnumerable<StatsHistoricalSummaryResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEnumerable<StatsHisoricalDailyResponse>> StatsHistoricalDailyByDateAsync(string date)
		{
			const string urlPattern = "stats/historical/daily";

			var qsb = new QueryStringBuilder();
			qsb.Add("date", date);

			var pathNvc = new NameValueCollection();

			return await _executor.ExecuteAsyncLegacy<IEnumerable<StatsHisoricalDailyResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEnumerable<StatsHisoricalDailyResponse>> StatsHistoricalDailyByLastAsync(int last)
		{
			const string urlPattern = "stats/historical/daily";

			var qsb = new QueryStringBuilder();
			qsb.Add("last", last);

			var pathNvc = new NameValueCollection();

			return await _executor.ExecuteAsyncLegacy<IEnumerable<StatsHisoricalDailyResponse>>(urlPattern, pathNvc, qsb);
		}
	}
}