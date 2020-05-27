using System.Linq;
using System.Threading.Tasks;
using IEXSharp;
using NUnit.Framework;

namespace IEXSharpTest.Cloud.PremiumData
{
	public class BrainCompanyTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.publishableToken, TestGlobal.secretToken, false, true);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task ThirtyDaySentimentIndicatorAsyncTest(string symbol)
		{
			var response = await sandBoxClient.BrainCompanyService.ThirtyDaySentimentIndicatorAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().SentimentScore);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task SevenDaySentimentIndicatorAsyncTest(string symbol)
		{
			var response = await sandBoxClient.BrainCompanyService.SevenDaySentimentIndicatorAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().SentimentScore);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task TwentyOneDayMachineLearningEstimatedReturnRankingAsyncTest(string symbol)
		{
			var response = await sandBoxClient.BrainCompanyService.TwentyOneDayMachineLearningEstimatedReturnRankingAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().MlAlpha);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task TenDayMachineLearningEstimatedReturnRankingAsyncTest(string symbol)
		{
			var response = await sandBoxClient.BrainCompanyService.TenDayMachineLearningEstimatedReturnRankingAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().MlAlpha);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task FiveDayMachineLearningEstimatedReturnRankingAsyncTest(string symbol)
		{
			var response = await sandBoxClient.BrainCompanyService.FiveDayMachineLearningEstimatedReturnRankingAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().MlAlpha);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task ThreeDayMachineLearningEstimatedReturnRankingAsyncTest(string symbol)
		{
			var response = await sandBoxClient.BrainCompanyService.ThreeDayMachineLearningEstimatedReturnRankingAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().MlAlpha);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task TwoDayMachineLearningEstimatedReturnRankingAsyncTest(string symbol)
		{
			var response = await sandBoxClient.BrainCompanyService.TwoDayMachineLearningEstimatedReturnRankingAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().MlAlpha);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task LanguageMetricsOnCompanyFilingsQuarterlyAndAnnualAsyncTest(string symbol)
		{
			var response = await sandBoxClient.BrainCompanyService.LanguageMetricsOnCompanyFilingsQuarterlyAndAnnualAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().Sentiment);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task LanguageMetricsOnCompanyFilingsAnnualOnlyAsyncTest(string symbol)
		{
			var response = await sandBoxClient.BrainCompanyService.LanguageMetricsOnCompanyFilingsAnnualOnlyAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().Sentiment);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task DifferencesInLanguageMetricsOnCompanyFilingsQuarterlyAndAnnualFromPriorPeriodAsyncTest(string symbol)
		{
			var response = await sandBoxClient.BrainCompanyService.DifferencesInLanguageMetricsOnCompanyFilingsQuarterlyAndAnnualFromPriorPeriodAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().SimilarityAll);
		}

		[Test]
		[TestCase("")]
		[TestCase("AAPL")]
		public async Task DifferencesInLanguageMetricsOnCompanyAnnualFilingsFromPriorYearAsyncTest(string symbol)
		{
			var response = await sandBoxClient.BrainCompanyService.DifferencesInLanguageMetricsOnCompanyAnnualFilingsFromPriorYearAsync(symbol);

			Assert.IsNull(response.ErrorMessage);
			Assert.IsNotNull(response.Data);
			Assert.IsNotNull(response.Data.First().SimilarityAll);
		}
	}
}