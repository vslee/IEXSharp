using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.PremiumData.BrainCompany.Response;

namespace IEXSharp.Service.Cloud.PremiumData.BrainCompany
{
	public class BrainCompanyService : IBrainCompanyService
	{
		private readonly ExecutorREST executor;

		internal BrainCompanyService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<IEnumerable<SentimentIndicatorResponse>>> ThirtyDaySentimentIndicatorAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SentimentIndicatorResponse>>($"time-series/PREMIUM_BRAIN_SENTIMENT_30_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<SentimentIndicatorResponse>>> SevenDaySentimentIndicatorAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SentimentIndicatorResponse>>($"time-series/PREMIUM_BRAIN_SENTIMENT_7_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> TwentyOneDayMachineLearningEstimatedReturnRankingAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EstimatedReturnRankingResponse>>($"time-series/PREMIUM_BRAIN_RANKING_21_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> TenDayMachineLearningEstimatedReturnRankingAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EstimatedReturnRankingResponse>>($"time-series/PREMIUM_BRAIN_RANKING_10_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> FiveDayMachineLearningEstimatedReturnRankingAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EstimatedReturnRankingResponse>>($"time-series/PREMIUM_BRAIN_RANKING_5_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> ThreeDayMachineLearningEstimatedReturnRankingAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EstimatedReturnRankingResponse>>($"time-series/PREMIUM_BRAIN_RANKING_3_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> TwoDayMachineLearningEstimatedReturnRankingAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EstimatedReturnRankingResponse>>($"time-series/PREMIUM_BRAIN_RANKING_2_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<LanguageMetricsOnCompanyFilingsResponse>>> LanguageMetricsOnCompanyFilingsQuarterlyAndAnnualAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<LanguageMetricsOnCompanyFilingsResponse>>($"time-series/PREMIUM_BRAIN_LANGUAGE_METRICS_ALL/{symbol}");

		public async Task<IEXResponse<IEnumerable<LanguageMetricsOnCompanyFilingsResponse>>> LanguageMetricsOnCompanyFilingsAnnualOnlyAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<LanguageMetricsOnCompanyFilingsResponse>>($"time-series/PREMIUM_BRAIN_LANGUAGE_METRICS_10K/{symbol}");

		public async Task<IEXResponse<IEnumerable<DifferencesInLanguageMetricsOnCompanyFilingsResponse>>> DifferencesInLanguageMetricsOnCompanyFilingsQuarterlyAndAnnualFromPriorPeriodAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<DifferencesInLanguageMetricsOnCompanyFilingsResponse>>($"time-series/PREMIUM_BRAIN_LANGUAGE_DIFFERENCES_ALL/{symbol}");

		public async Task<IEXResponse<IEnumerable<DifferencesInLanguageMetricsOnCompanyFilingsResponse>>> DifferencesInLanguageMetricsOnCompanyAnnualFilingsFromPriorYearAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<DifferencesInLanguageMetricsOnCompanyFilingsResponse>>($"time-series/PREMIUM_BRAIN_LANGUAGE_DIFFERENCES_10K/{symbol}");
	}
}