namespace ZH.Code.IEX.V2.Model.InvestorsExchangeData.Response
{
    public class TOPResponse
    {
        public string symbol { get; set; }
        public int bidSize { get; set; }
        public decimal bidPrice { get; set; }
        public int askSize { get; set; }
        public decimal askPrice { get; set; }
        public int volume { get; set; }
        public decimal lastSalePrice { get; set; }
        public int lastSaleSize { get; set; }
        public object lastSaleTime { get; set; }
        public object lastUpdated { get; set; }
        public string sector { get; set; }
        public string securityType { get; set; }
    }
}