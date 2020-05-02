using IEXSharp.Service.V2.CorporateActions;
using IEXSharp.Service.V2.StockFundamentals;
using IEXSharp.Service.V2.StockPrices;
using IEXSharp.Service.V2.StockProfiles;
using IEXSharp.Service.V2.StockResearch;
using System;
using System.Net.Http;
using VSLee.IEXSharp.Service.Cloud.Account;
using VSLee.IEXSharp.Service.Cloud.AlternativeData;
using VSLee.IEXSharp.Service.Cloud.APISystemMetadata;
using VSLee.IEXSharp.Service.Cloud.Crypto;
using VSLee.IEXSharp.Service.Cloud.ForexCurrencies;
using VSLee.IEXSharp.Service.Cloud.InvestorsExchangeData;
using VSLee.IEXSharp.Service.Cloud.ReferenceData;
using VSLee.IEXSharp.Service.Cloud.Stock;

namespace VSLee.IEXSharp
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
		private IStockService stockService;
		private ISSEService sseService;
		private IAlternativeDataService alternativeDataService;
		private ICryptoService cryptoService;
		private IReferenceDataService referenceDataService;
		private IForexCurrenciesService forexCurrenciesService;
		private IInvestorsExchangeDataService investorsExchangeDataService;
		private IAPISystemMetadataService apiSystemMetadataService;
		private ICorporateActionsService corporateActionsService;

		public IAccountService Account => accountService ??	(accountService =
			new AccountService(client, secretToken, publishableToken, signRequest));

		public IStockPricesService StockPrices => stockPricesService ?? (stockPricesService =
			new StockPricesService(client, secretToken, publishableToken, signRequest));

		public IStockProfilesService StockProfiles => stockProfilesService ?? (stockProfilesService =
			new StockProfilesService(client, secretToken, publishableToken, signRequest));

		public IStockFundamentalsService StockFundamentals => stockFundamentalsService ?? (stockFundamentalsService =
			new StockFundamentalsService(client, secretToken, publishableToken, signRequest));

		public IStockResearchService StockResearch => stockResearchService ?? (stockResearchService =
			new StockResearchService(client, secretToken, publishableToken, signRequest));

		public IStockService Stock => stockService ?? (stockService =
			new StockService(client, secretToken, publishableToken, signRequest));

		/// <summary> SSE streaming service </summary>
		public ISSEService SSE => sseService ?? (sseService =
			new SSEService(baseSSEURL: baseSSEURL, sk: secretToken, pk: publishableToken));

		public IAlternativeDataService AlternativeData => alternativeDataService ??
			(alternativeDataService = new AlternativeDataService(client, secretToken, publishableToken, signRequest));

		public ICryptoService Crypto => cryptoService ??
		    (cryptoService = new CryptoService(client, secretToken, publishableToken, signRequest));

		public IReferenceDataService ReferenceData => referenceDataService ??
			(referenceDataService = new ReferenceDataService(client, secretToken, publishableToken, signRequest));

		public IForexCurrenciesService ForexCurrencies => forexCurrenciesService ??
			(forexCurrenciesService = new ForexCurrenciesService(client, secretToken, publishableToken, signRequest));

		public IInvestorsExchangeDataService InvestorsExchangeData =>
			investorsExchangeDataService ?? (investorsExchangeDataService = new InvestorsExchangeDataService(client, secretToken, publishableToken, signRequest));

		public IAPISystemMetadataService ApiSystemMetadata => apiSystemMetadataService
			?? (apiSystemMetadataService = new APISystemMetadata(client, secretToken, publishableToken, signRequest));

		public ICorporateActionsService CorporateActions => corporateActionsService
			?? (corporateActionsService = new CorporateActionsService(client, secretToken, publishableToken, signRequest));

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