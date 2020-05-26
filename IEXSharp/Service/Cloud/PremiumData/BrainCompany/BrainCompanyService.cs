using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.PremiumData.FraudFactors.Response;

namespace IEXSharp.Service.Cloud.PremiumData.BrainCompany
{
	public class BrainCompanyService : IBrainCompanyService
	{
		private readonly ExecutorREST executor;

		internal BrainCompanyService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> ThirtyDaySentimentIndicator(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SimilarityIndexResponse>>($"time-series/PREMIUM_BRAIN_SENTIMENT_30_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> SevenDaySentimentIndicator(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SimilarityIndexResponse>>($"time-series/PREMIUM_BRAIN_SENTIMENT_7_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> TwentyOneDayMachineLearningEstimatedReturnRanking(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SimilarityIndexResponse>>($"time-series/PREMIUM_BRAIN_RANKING_21_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> TenDayMachineLearningEstimatedReturnRanking(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SimilarityIndexResponse>>($"time-series/PREMIUM_BRAIN_RANKING_10_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> FiveDayMachineLearningEstimatedReturnRanking(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SimilarityIndexResponse>>($"time-series/PREMIUM_BRAIN_RANKING_5_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> ThreeDayMachineLearningEstimatedReturnRanking(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SimilarityIndexResponse>>($"time-series/PREMIUM_BRAIN_RANKING_3_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> TwoDayMachineLearningEstimatedReturnRanking(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SimilarityIndexResponse>>($"time-series/PREMIUM_BRAIN_RANKING_2_DAYS/{symbol}");

		public async Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> LanguageMetricsOnCompanyFilingsQuarterlyAndAnnual(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SimilarityIndexResponse>>($"time-series/PREMIUM_BRAIN_LANGUAGE_METRICS_ALL/{symbol}");

		public async Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> LanguageMetricsOnCompanyFilingsAnnualOnly(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SimilarityIndexResponse>>($"time-series/PREMIUM_BRAIN_LANGUAGE_METRICS_10K/{symbol}");

		public async Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> DifferencesInLanguageMetricsOnCompanyFilingsQuarterlyAndAnnualFromPriorPeriod(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SimilarityIndexResponse>>($"time-series/PREMIUM_BRAIN_LANGUAGE_DIFFERENCES_ALL/{symbol}");

		public async Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> DifferencesInLanguageMetricsOnCompanyAnnualFilingsFromPriorYear(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SimilarityIndexResponse>>($"time-series/PREMIUM_BRAIN_LANGUAGE_DIFFERENCES_10K/{symbol}");
	}
}