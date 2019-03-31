namespace IEXClient.Model.Stock.Response
{
    public class PriceTargetResponse
    {
        public string symbol { get; set; }
        public string updatedDate { get; set; }
        public decimal priceTargetAverage { get; set; }
        public decimal priceTargetHigh { get; set; }
        public decimal priceTargetLow { get; set; }
        public int numberOfAnalysts { get; set; }
    }
}