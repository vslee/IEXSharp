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

namespace IEXSharp
{
	/// <summary> https://iexcloud.io/docs/api/#api-versioning </summary>
	public enum APIVersion
	{
		stable, latest, beta, V1
	}

	public class IEXCloudClient : IDisposable
	{
		private readonly HttpClient client;
		private readonly string baseSSEURL;
		private readonly string publishableToken;
		private readonly string secretToken;
		private readonly bool signRequest;

		private IAccountService accountService;
		private IStockPricesService stockPricesService;
		private IStockProfilesService stockProfilesService;
		private IStockFundamentalsService stockFundamentalsService;
		private IStockResearchService stockResearchService;
		private IBatchService batchService;
		private ICryptoService cryptoService;
		private IReferenceDataService referenceDataService;
		private IForexCurrenciesService forexCurrenciesService;
		private IInvestorsExchangeDataService investorsExchangeDataService;
		private IAPISystemMetadataService apiSystemMetadataService;
		private ICorporateActionsService corporateActionsService;
		private IMarketInfoService marketInfoService;
		private IOptionsService optionsService;
		private ICeoCompensationService ceoCompensationService;
		private ISocialSentimentService socialSentimentService;
		private ITreasuriesService treasuriesService;
		private INewsService newsService;
		private IEconomicDataService economicDataService;
		private ICommoditiesService commoditiesService;

		public IAccountService Account => accountService ??	(accountService =
			new AccountService(client, publishableToken, secretToken, signRequest));

		public IStockPricesService StockPrices => stockPricesService ?? (stockPricesService =
			new StockPricesService(client, baseSSEURL, publishableToken, secretToken, signRequest));

		public IStockProfilesService StockProfiles => stockProfilesService ?? (stockProfilesService =
			new StockProfilesService(client, publishableToken, secretToken, signRequest));

		public IStockFundamentalsService StockFundamentals => stockFundamentalsService ?? (stockFundamentalsService =
			new StockFundamentalsService(client, publishableToken, secretToken, signRequest));

		public IStockResearchService StockResearch => stockResearchService ?? (stockResearchService =
			new StockResearchService(client, publishableToken, secretToken, signRequest));

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
		/// Currently only available for /stock endpoints
		/// </summary>
		public IBatchService Batch => batchService ?? (batchService =
			new BatchService(client, publishableToken, secretToken, signRequest));

		public ICryptoService Crypto => cryptoService ??
		    (cryptoService = new CryptoService(client, baseSSEURL, publishableToken, secretToken, signRequest));

		public IReferenceDataService ReferenceData => referenceDataService ??
			(referenceDataService = new ReferenceDataService(client, publishableToken, secretToken, signRequest));

		public IForexCurrenciesService ForexCurrencies => forexCurrenciesService ??
			(forexCurrenciesService = new ForexCurrenciesService(client, publishableToken, secretToken, signRequest));

		public IInvestorsExchangeDataService InvestorsExchangeData =>
			investorsExchangeDataService ?? (investorsExchangeDataService = new InvestorsExchangeDataService(client, publishableToken, secretToken, signRequest));

		public IAPISystemMetadataService ApiSystemMetadata => apiSystemMetadataService
			?? (apiSystemMetadataService = new APISystemMetadata(client, publishableToken, secretToken, signRequest));

		public ICorporateActionsService CorporateActions => corporateActionsService
			?? (corporateActionsService = new CorporateActionsService(client, publishableToken, secretToken, signRequest));

		public IMarketInfoService MarketInfoService => marketInfoService
			?? (marketInfoService = new MarketInfoService(client, publishableToken, secretToken, signRequest));

		public IOptionsService Options => optionsService
			?? (optionsService = new OptionsService(client, secretToken, publishableToken, signRequest));

		public ICeoCompensationService CeoCompensation => ceoCompensationService
			?? (ceoCompensationService = new CeoCompensationService(client, publishableToken, secretToken, signRequest));

		public ISocialSentimentService SocialSentiment => socialSentimentService
			?? (socialSentimentService = new SocialSentimentService(client, baseSSEURL, publishableToken, secretToken, signRequest));

		public ITreasuriesService Treasuries => treasuriesService
			?? (treasuriesService = new TreasuriesService(client, publishableToken, secretToken, signRequest));

		public INewsService News => newsService
			?? (newsService = new NewsService(client, baseSSEURL, publishableToken, secretToken, signRequest));

		public IEconomicDataService EconomicData => economicDataService
			?? (economicDataService = new EconomicDataService(client, publishableToken, secretToken, signRequest));

		public ICommoditiesService Commodities => commoditiesService
			?? (commoditiesService = new CommoditiesService(client, publishableToken, secretToken, signRequest));

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