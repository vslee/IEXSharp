using System;
using System.Collections.Generic;
using System.Text;

namespace IEXSharp.Model.Shared.Response
{
	public class QuoteSSE
	{
		/*
		 * [{"symbol":"SPY","companyName":"SPDR S&P 500 ETF Trust","primaryExchange":"cA SYENar","calculationPrice":"close",
		 * "open":315.4,"openTime":1584351961496,"close":317.2,"closeTime":1635176203741,"high":316.01,"low":315.82,
		 * "latestPrice":312.3,"latestSource":"Close","latestTime":"November 13, 2019","latestUpdate":1587651085840,
		 * "latestVolume":56344666,"iexRealtimePrice":315.54,"iexRealtimeSize":311,"iexLastUpdated":1630432623344,
		 * "delayedPrice":315.7,"delayedPriceTime":1645925124673,"extendedPrice":316.3,"extendedChange":0.2,
		 * "extendedChangePercent":0.00066,"extendedPriceTime":1641921532420,"previousClose":317,"previousVolume":48484000,
		 * "change":0.1,"changePercent":0.00033,"volume":56925834,"iexMarketPercent":0.015919655622469,"iexVolume":884347,
		 * "avgTotalVolume":58499185,"iexBidPrice":0,"iexBidSize":0,"iexAskPrice":0,"iexAskSize":0,"marketCap":0,"peRatio":null,
		 * "week52High":321.43,"week52Low":234.07,"ytdChange":0.23867825294908238,"lastTradeTime":1646907527032}]
		 */
		public string symbol { get; set; }
		public string companyName { get; set; }
		public string primaryExchange { get; set; }
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
		public long previousVolume { get; set; }
		public decimal change { get; set; }
		public decimal changePercent { get; set; }
		public long volume { get; set; }
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
		public long lastTradeTime { get; set; }
	}
}
