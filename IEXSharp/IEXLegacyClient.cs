using IEXSharp.Service.Legacy.Market;
using IEXSharp.Service.Legacy.ReferenceData;
using IEXSharp.Service.Legacy.Stats;
using IEXSharp.Service.Legacy.Stock;
using System;
using System.Net.Http;
using IEXSharp.Helper;

namespace IEXSharp
{
	/// <summary> Main class for IEX Legacy API. Deprecated methods have been removed. IDisposable </summary>
	public class IEXLegacyClient : IDisposable
	{
		private readonly HttpClient _client;

		private readonly ExecutorREST executor;

		private IStockService stockService;
		private IReferenceDataService referenceDataService;
		private IMarketService marketService;
		private IStatsService statsService;

		public IStockService Stock =>
			stockService ?? (stockService = new StockService(executor));

		public IReferenceDataService ReferenceData => referenceDataService ??
			(referenceDataService = new ReferenceDataService(executor));

		public IMarketService Market =>
			marketService ?? (marketService = new MarketService(executor));

		public IStatsService Stats =>
			statsService ?? (statsService = new StatsService(executor));

		/// <summary> create a new IEXLegacyClient. No API keys are needed. </summary>
		public IEXLegacyClient()
		{
			_client = new HttpClient
			{
				BaseAddress = new Uri("https://api.iextrading.com/1.0/")
			};
			_client.DefaultRequestHeaders.Add("User-Agent", "IEXSharp IEX Legacy .Net");

			executor = new ExecutorREST(_client, string.Empty, string.Empty, false);
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