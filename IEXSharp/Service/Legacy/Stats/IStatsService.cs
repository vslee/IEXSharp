using IEXSharp.Model.InvestorsExchangeData.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;

namespace IEXSharp.Service.Legacy.Stats
{
	public interface IStatsService
	{
		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#intraday"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<StatsIntradayResponse>> StatsIntradayAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#recent"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<StatsRecentResponse>>> StatsRecentAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#records"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<StatsRecordResponse>> StatsRecordAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#historical-summary"/>
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<StatsHistoricalSummaryResponse>>> StatsHistoricalSummaryAsync(DateTime? date = null);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#historical-daily"/>
		/// </summary>
		/// <param name="last">Up to 90</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<StatsHisoricalDailyResponse>>> StatsHistoricalDailyByLastAsync(int last);
	}
}