using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.PremiumData.BrainCompany.Response;

namespace IEXSharp.Service.Cloud.PremiumData.BrainCompany
{
	public interface IBrainCompanyService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-30-day-sentiment-indicator"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SentimentIndicatorResponse>>> ThirtyDaySentimentIndicatorAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-7-day-sentiment-indicator"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SentimentIndicatorResponse>>> SevenDaySentimentIndicatorAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-21-day-machine-learning-estimated-return-ranking"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> TwentyOneDayMachineLearningEstimatedReturnRankingAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-10-day-machine-learning-estimated-return-ranking"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> TenDayMachineLearningEstimatedReturnRankingAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-5-day-machine-learning-estimated-return-ranking"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> FiveDayMachineLearningEstimatedReturnRankingAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-3-day-machine-learning-estimated-return-ranking"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> ThreeDayMachineLearningEstimatedReturnRankingAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-2-day-machine-learning-estimated-return-ranking"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EstimatedReturnRankingResponse>>> TwoDayMachineLearningEstimatedReturnRankingAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-language-metrics-on-company-filings-quarterly-and-annual"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<LanguageMetricsOnCompanyFilingsResponse>>> LanguageMetricsOnCompanyFilingsQuarterlyAndAnnualAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-language-metrics-on-company-filings-annual-only"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<LanguageMetricsOnCompanyFilingsResponse>>> LanguageMetricsOnCompanyFilingsAnnualOnlyAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-differences-in-language-metrics-on-company-filings-quarterly-and-annual-from-prior-period"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<DifferencesInLanguageMetricsOnCompanyFilingsResponse>>> DifferencesInLanguageMetricsOnCompanyFilingsQuarterlyAndAnnualFromPriorPeriodAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-companys-differences-in-language-metrics-on-company-annual-filings-from-prior-year"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<DifferencesInLanguageMetricsOnCompanyFilingsResponse>>> DifferencesInLanguageMetricsOnCompanyAnnualFilingsFromPriorYearAsync(string symbol);
	}
}
