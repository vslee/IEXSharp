namespace IEXSharp.Model.Shared.Response
{
	public class Quote
	{
		public string symbol { get; set; }
		public string companyName { get; set; }
		public string primaryExchange { get; set; }
		public string calculationPrice { get; set; }
		public decimal? open { get; set; }
		public long? openTime { get; set; }
		public string openSource { get; set; }
		public decimal? close { get; set; }
		public long? closeTime { get; set; }
		public string closeSource { get; set; }
		public decimal? high { get; set; }
		public long? highTime { get; set; }
		public string highSource { get; set; }
		public decimal? low { get; set; }
		public long? lowTime { get; set; }
		public string lowSource { get; set; }
		public decimal? latestPrice { get; set; }
		public string latestSource { get; set; }
		public string latestTime { get; set; }
		public long? latestUpdate { get; set; }
		public long? latestVolume { get; set; }
		public decimal? iexRealtimePrice { get; set; }
		public int? iexRealtimeSize { get; set; }
		public long? iexLastUpdated { get; set; }
		public decimal? delayedPrice { get; set; }
		public long? delayedPriceTime { get; set; }
		public decimal? oddLotDelayedPrice { get; set; }
		public decimal? oddLotDelayedPriceTime { get; set; }
		public decimal? extendedPrice { get; set; }
		public decimal? extendedChange { get; set; }
		public decimal? extendedChangePercent { get; set; }
		public long? extendedPriceTime { get; set; }
		public decimal? previousClose { get; set; }
		public decimal? previousVolume { get; set; }
		public decimal? change { get; set; }
		public decimal? changePercent { get; set; }
		public decimal? volume { get; set; }
		public decimal? iexMarketPercent { get; set; }
		public long? iexVolume { get; set; }
		public long? avgTotalVolume { get; set; }
		public decimal? iexBidPrice { get; set; }
		public int? iexBidSize { get; set; }
		public decimal? iexAskPrice { get; set; }
		public int? iexAskSize { get; set; }
		public decimal? iexOpen { get; set; }
		public decimal? iexOpenTime { get; set; }
		public decimal? iexClose { get; set; }
		public long? iexCloseTime { get; set; }
		public long? marketCap { get; set; }
		public decimal? peRatio { get; set; }
		public decimal? week52High { get; set; }
		public decimal? week52Low { get; set; }
		public decimal? ytdChange { get; set; }
		public long? lastTradeTime { get; set; }
		public bool isUSMarketOpen { get; set; }
		public string sector { get; set; }
	}
}
