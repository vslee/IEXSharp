using IEXClient.Model.InvestorsExchangeData.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEXClient.Service.V1.Stats
{
    public interface IStatsService
    {
        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#intraday"/>
        /// </summary>
        /// <returns></returns>
        Task<StatsIntradayResponse> StatsIntradayAsync();

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#recent"/>
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<StatsRecentResponse>> StatsRecentAsync();

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#records"/>
        /// </summary>
        /// <returns></returns>
        Task<StatsRecordResponse> StatsRecordAsync();

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#historical-summary"/>
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<IEnumerable<StatsHistoricalSummaryResponse>> StatsHistoricalSummaryAsync(DateTime? date = null);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#historical-daily"/>
        /// </summary>
        /// <param name="last">Up to 90</param>
        /// <returns></returns>
        Task<IEnumerable<StatsHisoricalDailyResponse>> StatsHistoricalDailyByLastAsync(int last);

        /// <summary>
        /// <see cref="https://iextrading.com/developer/docs/#historical-daily"/>
        /// </summary>
        /// <param name="date">yyyyMM or yyyyMMdd</param>
        /// <returns></returns>
        Task<IEnumerable<StatsHisoricalDailyResponse>> StatsHistoricalDailyByDateAsync(string date);
    }
}