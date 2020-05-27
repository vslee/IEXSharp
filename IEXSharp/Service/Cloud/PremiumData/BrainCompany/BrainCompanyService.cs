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

		public async Task<IEXResponse<IEnumerable<SentimentIndicatorResponse>>> ThirtyDaySentimentIndicator(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SentimentIndicatorResponse>>($"time-series/PREMIUM_BRAIN_SENTIMENT_30_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<SentimentIndicatorResponse>>> SevenDaySentimentIndicator(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SentimentIndicatorResponse>>($"time-series/PREMIUM_BRAIN_SENTIMENT_7_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> TwentyOneDayMachineLearningEstimatedReturnRanking(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EstimatedReturnRankingResponse>>($"time-series/PREMIUM_BRAIN_RANKING_21_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> TenDayMachineLearningEstimatedReturnRanking(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EstimatedReturnRankingResponse>>($"time-series/PREMIUM_BRAIN_RANKING_10_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> FiveDayMachineLearningEstimatedReturnRanking(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EstimatedReturnRankingResponse>>($"time-series/PREMIUM_BRAIN_RANKING_5_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> ThreeDayMachineLearningEstimatedReturnRanking(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EstimatedReturnRankingResponse>>($"time-series/PREMIUM_BRAIN_RANKING_3_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> TwoDayMachineLearningEstimatedReturnRanking(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EstimatedReturnRankingResponse>>($"time-series/PREMIUM_BRAIN_RANKING_2_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<LanguageMetricsOnCompanyFilingsResponse>>> LanguageMetricsOnCompanyFilingsQuarterlyAndAnnual(string symbol) =>
			await executor.NoParamExecute<IEnumerable<LanguageMetricsOnCompanyFilingsResponse>>($"time-series/PREMIUM_BRAIN_LANGUAGE_METRICS_ALL/{symbol}");

		public async Task<IEXResponse<IEnumerable<LanguageMetricsOnCompanyFilingsResponse>>> LanguageMetricsOnCompanyFilingsAnnualOnly(string symbol) =>
			await executor.NoParamExecute<IEnumerable<LanguageMetricsOnCompanyFilingsResponse>>($"time-series/PREMIUM_BRAIN_LANGUAGE_METRICS_10K/{symbol}");

		public async Task<IEXResponse<IEnumerable<DifferencesInLanguageMetricsOnCompanyFilingsResponse>>> DifferencesInLanguageMetricsOnCompanyFilingsQuarterlyAndAnnualFromPriorPeriod(string symbol) =>
			await executor.NoParamExecute<IEnumerable<DifferencesInLanguageMetricsOnCompanyFilingsResponse>>($"time-series/PREMIUM_BRAIN_LANGUAGE_DIFFERENCES_ALL/{symbol}");

		public async Task<IEXResponse<IEnumerable<DifferencesInLanguageMetricsOnCompanyFilingsResponse>>> DifferencesInLanguageMetricsOnCompanyAnnualFilingsFromPriorYear(string symbol) =>
			await executor.NoParamExecute<IEnumerable<DifferencesInLanguageMetricsOnCompanyFilingsResponse>>($"time-series/PREMIUM_BRAIN_LANGUAGE_DIFFERENCES_10K/{symbol}");
	}
}