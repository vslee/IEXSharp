using System;
using System.Net.Http;
using IEXSharp.Service.V2.Account;
using IEXSharp.Service.V2.AlternativeData;
using IEXSharp.Service.V2.APISystemMetadata;
using IEXSharp.Service.V2.ForexCurrencies;
using IEXSharp.Service.V2.InvestorsExchangeData;
using IEXSharp.Service.V2.ReferenceData;
using IEXSharp.Service.V2.Stock;

namespace IEXSharp
{
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

		public IEXCloudClient(string pk, string sk, bool signRequest, bool sandBox)
		{
			this.pk = pk;
			this.sk = sk;
			client = new HttpClient
			{
				BaseAddress = sandBox
					? new Uri("https://sandbox.iexapis.com/beta/")
					: new Uri("https://cloud.iexapis.com/beta/")
			};
			baseSSEURL = sandBox
				? "https://sandbox-sse.iexapis.com/stable/"
				: "https://cloud-sse.iexapis.com/stable/";
			client.DefaultRequestHeaders.Add("User-Agent", "zh-code.com IEX API V2 .Net Wrapper");
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