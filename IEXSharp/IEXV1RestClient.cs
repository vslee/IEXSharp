using VSLee.IEXSharp.Service.V1.Market;
using VSLee.IEXSharp.Service.V1.ReferenceData;
using VSLee.IEXSharp.Service.V1.Stats;
using VSLee.IEXSharp.Service.V1.Stock;
using System;
using System.Net.Http;

namespace VSLee.IEXSharp
{
	public class IEXV1RestClient : IDisposable
	{
		private readonly HttpClient _client;

		private IStockService stockService;
		private IReferenceDataService referenceDataService;
		private IMarketService marketService;
		private IStatsService statsService;

		public IStockService Stock
		{
			get => stockService ?? (stockService = new StockService(_client));
		}

		public IReferenceDataService ReferenceData
		{
			get => referenceDataService ?? (referenceDataService = new ReferenceDataService(_client));
		}

		public IMarketService Market
		{
			get => marketService ?? (marketService = new MarketService(_client));
		}

		public IStatsService Stats
		{
			get => statsService ?? (statsService = new StatsService(_client));
		}

		public IEXV1RestClient()
		{
			_client = new HttpClient
			{
				BaseAddress = new Uri("https://api.iextrading.com/1.0/")
			};
			_client.DefaultRequestHeaders.Add("User-Agent", "zh-code.com IEX API V1 .Net Wrapper");
		}

		private bool disposed;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_client.Dispose();
				}
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