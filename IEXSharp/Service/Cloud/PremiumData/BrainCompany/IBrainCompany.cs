using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.PremiumData.FraudFactors.Response;

namespace IEXSharp.Service.Cloud.PremiumData.BrainCompany
{
	public interface IBrainCompanyService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-30-day-sentiment-indicator"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> ThirtyDaySentimentIndicator(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-7-day-sentiment-indicator"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> SevenDaySentimentIndicator(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-21-day-machine-learning-estimated-return-ranking"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> TwentyOneDayMachineLearningEstimatedReturnRanking(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-10-day-machine-learning-estimated-return-ranking"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> TenDayMachineLearningEstimatedReturnRanking(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-5-day-machine-learning-estimated-return-ranking"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> FiveDayMachineLearningEstimatedReturnRanking(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-3-day-machine-learning-estimated-return-ranking"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> ThreeDayMachineLearningEstimatedReturnRanking(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-2-day-machine-learning-estimated-return-ranking"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> TwoDayMachineLearningEstimatedReturnRanking(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-language-metrics-on-company-filings-quarterly-and-annual"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> LanguageMetricsOnCompanyFilingsQuarterlyAndAnnual(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-language-metrics-on-company-filings-annual-only"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> LanguageMetricsOnCompanyFilingsAnnualOnly(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-differences-in-language-metrics-on-company-filings-quarterly-and-annual-from-prior-period"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> DifferencesInLanguageMetricsOnCompanyFilingsQuarterlyAndAnnualFromPriorPeriod(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-differences-in-language-metrics-on-company-annual-filings-from-prior-year"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> DifferencesInLanguageMetricsOnCompanyAnnualFilingsFromPriorYear(string symbol);
	}
}
