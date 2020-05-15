using IEXSharp.Service.Cloud.Account;
using IEXSharp.Service.Cloud.APISystemMetadata;
using IEXSharp.Service.Cloud.Batch;
using IEXSharp.Service.Cloud.CeoCompensation;
using IEXSharp.Service.Cloud.Commodities;
using IEXSharp.Service.Cloud.CorporateActions;
using IEXSharp.Service.Cloud.Crypto;
using IEXSharp.Service.Cloud.EconomicData;
using IEXSharp.Service.Cloud.ForexCurrencies;
using IEXSharp.Service.Cloud.InvestorsExchangeData;
using IEXSharp.Service.Cloud.MarketInfo;
using IEXSharp.Service.Cloud.News;
using IEXSharp.Service.Cloud.Options;
using IEXSharp.Service.Cloud.ReferenceData;
using IEXSharp.Service.Cloud.SocialSentiment;
using IEXSharp.Service.Cloud.StockFundamentals;
using IEXSharp.Service.Cloud.StockPrices;
using IEXSharp.Service.Cloud.StockProfiles;
using IEXSharp.Service.Cloud.StockResearch;
using IEXSharp.Service.Cloud.Treasuries;
using System;
using System.Net.Http;
using IEXSharp.Helper;

namespace IEXSharp
{
	/// <summary> https://iexcloud.io/docs/api/#api-versioning </summary>
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

	/// <summary> Main class for IEX Cloud REST and SSE streaming IDisposable </summary>
	public class IEXCloudClient : IDisposable
	{
		/// <summary> only used for REST calls, not by the SSEClient </summary>
		private readonly HttpClient client;
		private readonly string baseSSEURL;
		private readonly string publishableToken;
		private readonly string secretToken;
		private readonly bool signRequest;

		private readonly ExecutorREST executor;
		private readonly ExecutorSSE executorSSE;

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

		// The following properties are arranged in the same order as https://iexcloud.io/docs/api

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
		/// Currently only available for /stock endpoints
		/// </summary>
		public IBatchService Batch => batchService ?? (batchService =
			new BatchService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#accounts"/>
		/// </summary>
		public IAccountService Account => accountService ??	(accountService =
			new AccountService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#api-system-metadata"/>
		/// </summary>
		public IAPISystemMetadataService ApiSystemMetadata => apiSystemMetadataService
			?? (apiSystemMetadataService = new APISystemMetadata(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stock-prices"/>
		/// </summary>
		public IStockPricesService StockPrices => stockPricesService ?? (stockPricesService =
			new StockPricesService(executor, executorSSE));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stock-profiles"/>
		/// </summary>
		public IStockProfilesService StockProfiles => stockProfilesService ?? (stockProfilesService =
			new StockProfilesService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stock-fundamentals"/>
		/// </summary>
		public IStockFundamentalsService StockFundamentals => stockFundamentalsService ?? (stockFundamentalsService =
			new StockFundamentalsService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stock-research"/>
		/// </summary>
		public IStockResearchService StockResearch => stockResearchService ?? (stockResearchService =
			new StockResearchService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#corporate-actions"/>
		/// </summary>
		public ICorporateActionsService CorporateActions => corporateActionsService
			?? (corporateActionsService = new CorporateActionsService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#market-info"/>
		/// </summary>
		public IMarketInfoService MarketInfoService => marketInfoService
			?? (marketInfoService = new MarketInfoService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#news"/>
		/// </summary>
		public INewsService News => newsService
			?? (newsService = new NewsService(executor, executorSSE));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency"/>
		/// </summary>
		public ICryptoService Crypto => cryptoService ??
		    (cryptoService = new CryptoService(executor, executorSSE));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#forex-currencies"/>
		/// </summary>
		public IForexCurrenciesService ForexCurrencies => forexCurrenciesService ??
			(forexCurrenciesService = new ForexCurrenciesService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#options"/>
		/// </summary>
		public IOptionsService Options => optionsService
			?? (optionsService = new OptionsService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#social-sentiment"/>
		/// </summary>
		public ISocialSentimentService SocialSentiment => socialSentimentService
			?? (socialSentimentService = new SocialSentimentService(executor, executorSSE));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#ceo-compensation"/>
		/// </summary>
		public ICeoCompensationService CeoCompensation => ceoCompensationService
			?? (ceoCompensationService = new CeoCompensationService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#treasuries"/>
		/// </summary>
		public ITreasuriesService Treasuries => treasuriesService
			?? (treasuriesService = new TreasuriesService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#commodities"/>
		/// </summary>
		public ICommoditiesService Commodities => commoditiesService
			?? (commoditiesService = new CommoditiesService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#economic-data"/>
		/// </summary>
		public IEconomicDataService EconomicData => economicDataService
			?? (economicDataService = new EconomicDataService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#reference-data"/>
		/// </summary>
		public IReferenceDataService ReferenceData => referenceDataService ??
			(referenceDataService = new ReferenceDataService(executor));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#investors-exchange-data"/>
		/// </summary>
		public IInvestorsExchangeDataService InvestorsExchangeData =>
			investorsExchangeDataService ?? (investorsExchangeDataService = new InvestorsExchangeDataService(executor));

		/// <summary>
		/// create a new IEXCloudClient
		/// </summary>
		/// <param name="publishableToken">publishable token</param>
		/// <param name="secretToken">secret token (only used for SCALE and GROW users)</param>
		/// <param name="signRequest">only SCALE and GROW users should set this to true</param>
		/// <param name="useSandBox">whether or not to use the sandbox endpoint</param>
		/// <param name="version">whether to use stable or beta endpoint</param>
		public IEXCloudClient(string publishableToken, string secretToken, bool signRequest, bool useSandBox, APIVersion version = APIVersion.stable)
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

			executor = new ExecutorREST(client, publishableToken, secretToken, signRequest);
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