using System.Collections.Generic;
using IEXClient.Model.Shared.Response;

namespace IEXClient.Model.InvestorsExchangeData.Response
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
        public DeepSystemEventResponse systemEvent { get; set; }
        public DeepTradingStatusResponse tradingStatus { get; set; }
        public DeepOperationalHaltStatusResponse opHaltStatus { get; set; }
        public DeepShortSalePriceTestStatusResponse ssrStatus { get; set; }
        public DeepSecurityEventResponse securityEvent { get; set; }
        public List<DeepTradeResponse> trades { get; set; }
        public List<DeepTradeResponse> tradeBreaks { get; set; }
        public DeepAuctionResponse auction { get; set; }
    }
}