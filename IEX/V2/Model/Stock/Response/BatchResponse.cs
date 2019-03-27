using System;
using System.Collections.Generic;
using System.Text;

namespace IEX.V2.Model.Stock.Response
{
    public class BatchQuote
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
        public int latestVolume { get; set; }
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
        public int iexBidPrice { get; set; }
        public int iexBidSize { get; set; }
        public int iexAskPrice { get; set; }
        public int iexAskSize { get; set; }
        public long marketCap { get; set; }
        public decimal peRatio { get; set; }
        public decimal week52High { get; set; }
        public decimal week52Low { get; set; }
        public decimal ytdChange { get; set; }
    }

    public class BatchNews
    {
        public long datetime { get; set; }
        public string headline { get; set; }
        public string source { get; set; }
        public string url { get; set; }
        public string summary { get; set; }
        public string related { get; set; }
        public string image { get; set; }
        public string lang { get; set; }
        public bool hasPaywall { get; set; }
    }

    public class BatchChart
    {
        public string date { get; set; }
        public decimal open { get; set; }
        public decimal close { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public int volume { get; set; }
        public decimal uOpen { get; set; }
        public decimal uClose { get; set; }
        public decimal uHigh { get; set; }
        public decimal uLow { get; set; }
        public int uVolume { get; set; }
        public decimal change { get; set; }
        public decimal changePercent { get; set; }
        public string label { get; set; }
        public decimal changeOverTime { get; set; }
    }
}
