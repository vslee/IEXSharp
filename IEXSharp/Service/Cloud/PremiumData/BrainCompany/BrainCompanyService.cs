using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.PremiumData.FraudFactors.Response;
using IEXSharp.Service.Cloud.PremiumData.FraudFactors;

namespace IEXSharp.Service.Cloud.PremiumData.BrainCompany
{
	public class BrainCompanyService : IBrainCompanyService
	{
		private readonly ExecutorREST executor;

		internal BrainCompanyService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> ThirtyDaySentimentIndicator(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> SevenDaySentimentIndicator(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> TwentyOneDayMachineLearningEstimatedReturnRanking(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> TenDayMachineLearningEstimatedReturnRanking(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> FiveDayMachineLearningEstimatedReturnRanking(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> ThreeDayMachineLearningEstimatedReturnRanking(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> TwoDayMachineLearningEstimatedReturnRanking(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> LanguageMetricsOnCompanyFilingsQuarterlyAndAnnual(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> LanguageMetricsOnCompanyFilingsAnnualOnly(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> DifferencesInLanguageMetricsOnCompanyFilingsQuarterlyAndAnnualFromPriorPeriod(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> DifferencesInLanguageMetricsOnCompanyAnnualFilingsFromPriorYear(string symbol)
		{
			throw new System.NotImplementedException();
		}
	}
}