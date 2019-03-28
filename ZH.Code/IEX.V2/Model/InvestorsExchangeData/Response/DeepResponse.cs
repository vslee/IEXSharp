using ZH.Code.IEX.V2.Model.Shared.Response;
using System.Collections.Generic;

namespace ZH.Code.IEX.V2.Model.InvestorsExchangeData.Response
{
    public class DeepResponse
    {
        public string symbol { get; set; }
        public decimal marketPercent { get; set; }
        public int volume { get; set; }
        public decimal lastSalePrice { get; set; }
        public int lastSaleSize { get; set; }
        public long lastSaleTime { get; set; }
        public long lastUpdated { get; set; }
        public List<Bid> bids { get; set; }
        public List<Ask> asks { get; set; }
        public SystemEvent systemEvent { get; set; }
        public TradingStatus tradingStatus { get; set; }
        public OpHaltStatus opHaltStatus { get; set; }
        public SsrStatus ssrStatus { get; set; }
        public SecurityEvent securityEvent { get; set; }
        public List<Trade> trades { get; set; }
        public List<Trade> tradeBreaks { get; set; }
        public Auction auction { get; set; }
    }
}