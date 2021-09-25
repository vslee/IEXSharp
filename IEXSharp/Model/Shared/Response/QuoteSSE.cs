namespace IEXSharp.Model.Shared.Response
{
	public class QuoteSSE
	{
		/*
		 * [{"symbol":"SPY","companyName":"SPDR S&P 500 ETF Trust","primaryExchange":"YrNEa cSA",
		 * "calculationPrice":"iexlasttrade","open":311.08,"openTime":1651221934569,
		 * "openSource":"cioiffla","close":317.99,"closeTime":1623982809221,"closeSource":"icfofila",
		 * "high":315,"highTime":1649584430018,"highSource":"trrea ElmpIe icXei ","low":310.33,
		 * "lowTime":1642350278876,"lowSource":"1re ydc ali5epint medeu","latestPrice":304.75,
		 * "latestSource":"IEX Last Trade","latestTime":"June 29, 2020","latestUpdate":1614947647740,
		 * "latestVolume":74072356,"iexRealtimePrice":317.21,"iexRealtimeSize":501,
		 * "iexLastUpdated":1620197243749,"delayedPrice":317.25,"delayedPriceTime":1641914583414,
		 * "oddLotDelayedPrice":307.18,"oddLotDelayedPriceTime":1658370935322,"extendedPrice":309.26,
		 * "extendedChange":0.43,"extendedChangePercent":0.00145,"extendedPriceTime":1637375292137,
		 * "previousClose":308.92,"previousVolume":130751620,"change":4.55,"changePercent":0.01505,
		 * "volume":73307676,"iexMarketPercent":0.01201437292318108,"iexVolume":860954,
		 * "avgTotalVolume":109282327,"iexBidPrice":314.78,"iexBidSize":524,"iexAskPrice":319.53,
		 * "iexAskSize":512,"iexOpen":null,"iexOpenTime":null,"iexClose":317.18,
		 * "iexCloseTime":1640052720926,"marketCap":279433374441,"peRatio":null,"week52High":343.44,
		 * "week52Low":219.18,"ytdChange":-0.06286420219690594,"lastTradeTime":1594323831281}]
		 */
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
		public long? oddLotDelayedPriceTime { get; set; }
		public decimal? extendedPrice { get; set; }
		public decimal? extendedChange { get; set; }
		public decimal? extendedChangePercent { get; set; }
		public long? extendedPriceTime { get; set; }
		public decimal? previousClose { get; set; }
		public decimal? previousVolume { get; set; }
		public decimal? change { get; set; }
		public decimal? changePercent { get; set; }
		public long? volume { get; set; }
		public decimal? iexMarketPercent { get; set; }
		public int? iexVolume { get; set; }
		public int? avgTotalVolume { get; set; }
		public decimal? iexBidPrice { get; set; }
		public int? iexBidSize { get; set; }
		public decimal? iexAskPrice { get; set; }
		public int? iexAskSize { get; set; }
		public decimal? iexOpen { get; set; }
		public long? iexOpenTime { get; set; }
		public decimal? iexClose { get; set; }
		public long? iexCloseTime { get; set; }
		public long? marketCap { get; set; }
		public decimal? peRatio { get; set; }
		public decimal? week52High { get; set; }
		public decimal? week52Low { get; set; }
		public decimal? ytdChange { get; set; }
		public long? lastTradeTime { get; set; }

		public override string ToString() =>
			$"{latestTime}:{symbol},{latestPrice},{latestVolume}";
	}
}
