using System;
using System.Net.Http;
using VSLee.IEXSharp.Service.V2.Account;
using VSLee.IEXSharp.Service.V2.AlternativeData;
using VSLee.IEXSharp.Service.V2.APISystemMetadata;
using VSLee.IEXSharp.Service.V2.ForexCurrencies;
using VSLee.IEXSharp.Service.V2.InvestorsExchangeData;
using VSLee.IEXSharp.Service.V2.ReferenceData;
using VSLee.IEXSharp.Service.V2.Stock;

namespace VSLee.IEXSharp
{
	/// <summary>
	/// https://iexcloud.io/docs/api/#api-versioning
	/// </summary>
	public enum APIVersion
	{
		stable, latest, beta, V1
	}

	public class IEXCloudClient : IDisposable
	{
		private readonly HttpClient client;
		private readonly string baseSSEURL;
		private readonly string pk;
		private readonly string sk;
		private readonly bool sign;

		private IAccountService accountService;
		private IStockService stockService;
		private ISSEService sseService;
		private IAlternativeDataService alternativeDataService;
		private IReferenceDataService referenceDataService;
		private IForexCurrenciesService forexCurrenciesService;
		private IInvestorsExchangeDataService investorsExchangeDataService;
		private IAPISystemMetadataService apiSystemMetadataService;

		public IAccountService Account
		{
			get =>
				accountService ??
				(accountService = new AccountService(client, sk, pk, sign));
		}

		public IStockService Stock
		{
			get => stockService ?? (stockService = new StockService(client, sk, pk, sign));
		}

		public ISSEService SSE
		{
			get => sseService ?? (sseService = new SSEService(baseSSEURL: baseSSEURL, sk: sk, pk: pk));
		}

		public IAlternativeDataService AlternativeData
		{
			get => alternativeDataService ?? (alternativeDataService = new AlternativeDataService(client, sk, pk, sign));
		}

		public IReferenceDataService ReferenceData
		{
			get => referenceDataService ?? (referenceDataService = new ReferenceDataService(client, sk, pk, sign));
		}

		public IForexCurrenciesService ForexCurrencies
		{
			get => forexCurrenciesService ?? (forexCurrenciesService = new ForexCurrenciesService(client, sk, pk, sign));
		}

		public IInvestorsExchangeDataService InvestorsExchangeData
		{
			get => investorsExchangeDataService ?? (investorsExchangeDataService = new InvestorsExchangeDataService(client, sk, pk, sign));
		}

		public IAPISystemMetadataService ApiSystemMetadata
		{
			get => apiSystemMetadataService ?? (apiSystemMetadataService = new APISystemMetadata(client, sk, pk, sign));
		}

		/// <summary>
		/// create a new IEXCloudClient
		/// </summary>
		/// <param name="pk">publishable token</param>
		/// <param name="sk">secret tokey (only used for SCALE and GROW users)</param>
		/// <param name="signRequest">only SCALE and GROW users should set this to true</param>
		/// <param name="useSandBox">whether or not to use the sandbox endpoint</param>
		/// <param name="version">whether to use stable or beta endpoint</param>
		public IEXCloudClient(string pk, string sk, bool signRequest, bool useSandBox, APIVersion version = APIVersion.stable)
		{
			if (string.IsNullOrWhiteSpace(pk))
			{
				throw new ArgumentException("pk cannot be null");
			}
			this.pk = pk;
			this.sk = sk;
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
			sign = signRequest;
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