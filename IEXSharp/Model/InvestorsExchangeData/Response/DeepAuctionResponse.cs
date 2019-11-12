namespace IEXSharp.Model.InvestorsExchangeData.Response
{
    public class DeepAuctionResponse
    {
        public string auctionType { get; set; }
        public int pairedShares { get; set; }
        public int imbalanceShares { get; set; }
        public decimal referencePrice { get; set; }
        public decimal indicativePrice { get; set; }
        public decimal auctionBookPrice { get; set; }
        public decimal collarReferencePrice { get; set; }
        public decimal lowerCollarPrice { get; set; }
        public decimal upperCollarPrice { get; set; }
        public int extensionNumber { get; set; }
        public string startTime { get; set; }
        public long lastUpdate { get; set; }
    }
}