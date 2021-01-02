using IEXSharp.Service.Cloud.Account;
using IEXSharp.Service.Cloud.APISystemMetadata;
using System;
using System.Net.Http;
using IEXSharp.Helper;
using IEXSharp.Service.Cloud.CoreData.Batch;
using IEXSharp.Service.Cloud.CoreData.CeoCompensation;
using IEXSharp.Service.Cloud.CoreData.Commodities;
using IEXSharp.Service.Cloud.CoreData.CorporateActions;
using IEXSharp.Service.Cloud.CoreData.Crypto;
using IEXSharp.Service.Cloud.CoreData.EconomicData;
using IEXSharp.Service.Cloud.CoreData.ForexCurrencies;
using IEXSharp.Service.Cloud.CoreData.InvestorsExchangeData;
using IEXSharp.Service.Cloud.CoreData.MarketInfo;
using IEXSharp.Service.Cloud.CoreData.News;
using IEXSharp.Service.Cloud.CoreData.Options;
using IEXSharp.Service.Cloud.CoreData.ReferenceData;
using IEXSharp.Service.Cloud.CoreData.SocialSentiment;
using IEXSharp.Service.Cloud.CoreData.StockFundamentals;
using IEXSharp.Service.Cloud.CoreData.StockPrices;
using IEXSharp.Service.Cloud.CoreData.StockProfiles;
using IEXSharp.Service.Cloud.CoreData.StockResearch;
using IEXSharp.Service.Cloud.CoreData.Treasuries;
using IEXSharp.Service.Cloud.PremiumData.AuditAnalytics;
using IEXSharp.Service.Cloud.PremiumData.BrainCompany;
using IEXSharp.Service.Cloud.PremiumData.ExtractAlpha;
using IEXSharp.Service.Cloud.PremiumData.FraudFactors;
using IEXSharp.Service.Cloud.PremiumData.PrecisionAlpha;
using IEXSharp.Service.Cloud.PremiumData.Kavout;
using IEXSharp.Service.Cloud.PremiumData.WallStreetHorizon;

namespace IEXSharp
{
	/// <summary> <see cref="https://iexcloud.io/docs/api/#api-versioning"/> </summary>
	public enum APIVersion
	{
		/// <summary> can be used to access the latest stable API version </summary>
		stable,
		/// <summary> can be used to access the latest API version which may be in beta </summary>
		latest,
		/// <summary> this will need to be revised when new beta versions appear (beta vs v2-beta)/ </summary>
		beta,
		/// <summary> current version </summary>
		V1
	}

	/// <summary> How you want to handle error 429 <see cref="https://iexcloud.io/docs/api/#request-limits"/> </summary>
	public enum RetryPolicy
	{
		/// <summary> No rate limiting, and pass errors through to the IEXResponse.ErrorMessage property </summary>
		Manual,
		/// <summary> No rate limiting, but eat error messages and print to Debug console instead </summary>
		NoWait,
		/// <summary> Linear backoff policy, which starts at 250ms and increases linearly with each successive "error 429" or "ServiceUnavailable". Eats error messages and prints to Debug console instead </summary>
		Linear,
		/// <summary> Exponential backoff policy, which starts at 250ms and increases exponentially with each successive "error 429" or "ServiceUnavailable". Eats error messages and prints to Debug console instead </summary>
		Exponential
	}

	/// <summary> Main class for IEX Cloud REST and SSE streaming IDisposable </summary>
	public class IEXCloudClient : IDisposable
	{
		/// <summary> only used for REST calls, not by the SSEClient </summary>
		private readonly HttpClient client;
		private readonly string baseSSEURL;
		private readonly string publishableToken;
		private readonly string secretToken;
		private readonly bool signRequest;

		private protected readonly ExecutorREST executor;
		private protected ExecutorSSE executorSSE;

		private IBatchService batchService;
		private IAccountService accountService;
		private IAPISystemMetadataService apiSystemMetadataService;
		private IStockPricesService stockPricesService;
		private IStockProfilesService stockProfilesService;
		private IStockFundamentalsService stockFundamentalsService;
		private IStockResearchService stockResearchService;
		private ICorporateActionsService corporateActionsService;
		private IMarketInfoService marketInfoService;
		private INewsService newsService;
		private ICryptoService cryptoService;
		private IForexCurrenciesService forexCurrenciesService;
		private IOptionsService optionsService;
		private ISocialSentimentService socialSentimentService;
		private ICeoCompensationService ceoCompensationService;
		private ITreasuriesService treasuriesService;
		private IEconomicDataService economicDataService;
		private ICommoditiesService commoditiesService;
		private IReferenceDataService referenceDataService;
		private IInvestorsExchangeDataService investorsExchangeDataService;
		private IWallStreetHorizonService wallStreetHorizonService;
		private IFraudFactorsService fraudFactorsService;
		private IExtractAlphaService extractAlphaService;
		private IPrecisionAlphaService precisionAlphaService;
		private IKavoutService kavoutService;
 		private IAuditAnalyticsService auditAnalyticsService;
        private IBrainCompanyService brainCompanyService;

		// The following properties are arranged in the same order as https://iexcloud.io/docs/api

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
		/// Currently only available for /stock endpoints
		/// </summary>
		public virtual IBatchService Batch => batchService
		    ?? (batchService = new BatchService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#accounts"/>
		/// </summary>
		public virtual IAccountService Account => accountService
			?? (accountService = new AccountService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#api-system-metadata"/>
		/// </summary>
		public virtual IAPISystemMetadataService ApiSystemMetadata => apiSystemMetadataService
			?? (apiSystemMetadataService = new APISystemMetadata(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stock-prices"/>
		/// </summary>
		public virtual IStockPricesService StockPrices => stockPricesService
			?? (stockPricesService = new StockPricesService(executor, executorSSE));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stock-profiles"/>
		/// </summary>
		public virtual IStockProfilesService StockProfiles => stockProfilesService
			?? (stockProfilesService = new StockProfilesService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stock-fundamentals"/>
		/// </summary>
		public virtual IStockFundamentalsService StockFundamentals => stockFundamentalsService
			?? (stockFundamentalsService = new StockFundamentalsService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stock-research"/>
		/// </summary>
		public virtual IStockResearchService StockResearch => stockResearchService
		    ?? (stockResearchService = new StockResearchService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#corporate-actions"/>
		/// </summary>
		public virtual ICorporateActionsService CorporateActions => corporateActionsService
			?? (corporateActionsService = new CorporateActionsService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#market-info"/>
		/// </summary>
		public virtual IMarketInfoService MarketInfoService => marketInfoService
			?? (marketInfoService = new MarketInfoService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#news"/>
		/// </summary>
		public virtual INewsService News => newsService
			?? (newsService = new NewsService(executor, executorSSE));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency"/>
		/// </summary>
		public virtual ICryptoService Crypto => cryptoService
		    ?? (cryptoService = new CryptoService(executor, executorSSE));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#forex-currencies"/>
		/// </summary>
		public virtual IForexCurrenciesService ForexCurrencies => forexCurrenciesService
			?? (forexCurrenciesService = new ForexCurrenciesService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#options"/>
		/// </summary>
		public virtual IOptionsService Options => optionsService
			?? (optionsService = new OptionsService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#social-sentiment"/>
		/// </summary>
		public virtual ISocialSentimentService SocialSentiment => socialSentimentService
			?? (socialSentimentService = new SocialSentimentService(executor, executorSSE));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#ceo-compensation"/>
		/// </summary>
		public virtual ICeoCompensationService CeoCompensation => ceoCompensationService
			?? (ceoCompensationService = new CeoCompensationService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#treasuries"/>
		/// </summary>
		public virtual ITreasuriesService Treasuries => treasuriesService
			?? (treasuriesService = new TreasuriesService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#commodities"/>
		/// </summary>
		public virtual ICommoditiesService Commodities => commoditiesService
			?? (commoditiesService = new CommoditiesService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#economic-data"/>
		/// </summary>
		public virtual IEconomicDataService EconomicData => economicDataService
			?? (economicDataService = new EconomicDataService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#reference-data"/>
		/// </summary>
		public virtual IReferenceDataService ReferenceData => referenceDataService
			?? (referenceDataService = new ReferenceDataService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#investors-exchange-data"/>
		/// </summary>
		public virtual IInvestorsExchangeDataService InvestorsExchangeDataService => investorsExchangeDataService
			?? (investorsExchangeDataService = new InvestorsExchangeDataService(executor, executorSSE));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#wall-street-horizon"/>
		/// </summary>
		public virtual IWallStreetHorizonService WallStreetHorizonService => wallStreetHorizonService
			?? (wallStreetHorizonService = new WallStreetHorizonService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#fraud-factors"/>
		/// </summary>
		public virtual IFraudFactorsService FraudFactorsService => fraudFactorsService
		    ?? (fraudFactorsService = new FraudFactorsService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#extractalpha"/>
		/// </summary>
		public virtual IExtractAlphaService ExtractAlphaService => extractAlphaService
		    ?? (extractAlphaService = new ExtractAlphaService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#precision-alpha"/>
		/// </summary>
		public virtual IPrecisionAlphaService PrecisionAlphaService => precisionAlphaService
		    ?? (precisionAlphaService = new PrecisionAlphaService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#kavout"/>
		/// </summary>
		public virtual IKavoutService KavoutService => kavoutService
		     ?? (kavoutService = new KavoutService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#audit-analytics"/>
		/// </summary>
		public virtual IAuditAnalyticsService AuditAnalyticsService => auditAnalyticsService
			?? (auditAnalyticsService = new AuditAnalyticsService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#brain-company"/>
		/// </summary>
		public virtual IBrainCompanyService BrainCompanyService => brainCompanyService
			?? (brainCompanyService = new BrainCompanyService(executor));

		/// <summary>
		/// create a new IEXCloudClient
		/// </summary>
		/// <param name="publishableToken">publishable token</param>
		/// <param name="secretToken">secret token (only used for SCALE and GROW users)</param>
		/// <param name="signRequest">only SCALE and GROW users should set this to true</param>
		/// <param name="useSandBox">whether or not to use the sandbox endpoint</param>
		/// <param name="version">whether to use stable or beta endpoint</param>
		/// <param name="retryPolicy">which backoff policy to use - applies only REST calls (not SSE)</param>
		public IEXCloudClient(string publishableToken, string secretToken, bool signRequest, bool useSandBox,
			APIVersion version = APIVersion.stable, RetryPolicy retryPolicy = RetryPolicy.Exponential)
		{
			if (string.IsNullOrWhiteSpace(publishableToken))
			{
				throw new ArgumentException("publishableToken cannot be null");
			}

			this.publishableToken = publishableToken;
			this.secretToken = secretToken;
			this.signRequest = signRequest;

			var baseAddress = useSandBox
				? "https://sandbox.iexapis.com/"
				: "https://cloud.iexapis.com/";
			baseAddress += version.ToString() + "/";
			baseSSEURL = useSandBox
				? "https://sandbox-sse.iexapis.com/"
				: "https://cloud-sse.iexapis.com/";
			baseSSEURL += version.ToString() + "/";
			client = new HttpClient
			{
				BaseAddress = new Uri(baseAddress)
			};
			client.DefaultRequestHeaders.Add("User-Agent", "VSLee.IEXSharp IEX Cloud .Net");

			executor = new ExecutorREST(client, publishableToken, secretToken,
				signRequest, retryPolicy);
			executorSSE = new ExecutorSSE(baseSSEURL, publishableToken, secretToken);
		}

		private bool disposed;
		protected virtual void Dispose(bool disposing)
		{
			if (!disposed && disposing)
			{
				client.Dispose();
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}