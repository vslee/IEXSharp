namespace VSLee.IEXSharp.Model.Shared.Response
{
	public class Quote
	{
		public string symbol { get; set; }
		public string companyName { get; set; }
		public string calculationPrice { get; set; }
		public decimal open { get; set; }
		public long openTime { get; set; }
		public decimal close { get; set; }
		public long closeTime { get; set; }
		public decimal high { get; set; }
		public decimal low { get; set; }
		public decimal latestPrice { get; set; }
		public string latestSource { get; set; }
		public string latestTime { get; set; }
		public long latestUpdate { get; set; }
		public long latestVolume { get; set; }
		public decimal iexRealtimePrice { get; set; }
		public int iexRealtimeSize { get; set; }
		public long iexLastUpdated { get; set; }
		public decimal delayedPrice { get; set; }
		public long delayedPriceTime { get; set; }
		public decimal extendedPrice { get; set; }
		public decimal extendedChange { get; set; }
		public decimal extendedChangePercent { get; set; }
		public long extendedPriceTime { get; set; }
		public decimal previousClose { get; set; }
		public decimal change { get; set; }
		public decimal changePercent { get; set; }
		public decimal iexMarketPercent { get; set; }
		public int iexVolume { get; set; }
		public int avgTotalVolume { get; set; }
		public decimal iexBidPrice { get; set; }
		public int iexBidSize { get; set; }
		public decimal iexAskPrice { get; set; }
		public int iexAskSize { get; set; }
		public long marketCap { get; set; }
		public decimal peRatio { get; set; }
		public decimal week52High { get; set; }
		public decimal week52Low { get; set; }
		public decimal ytdChange { get; set; }
		public decimal? bidPrice { get; set; }
		public decimal? bidSize { get; set; }
		public decimal? askPrice { get; set; }
		public decimal? askSize { get; set; }
	}
}