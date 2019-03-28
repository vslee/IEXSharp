namespace ZH.Code.IEX.V2.Model.Shared.Response
{
    public class Trade
    {
        public decimal price { get; set; }
        public int size { get; set; }
        public int tradeId { get; set; }
        public bool isISO { get; set; }
        public bool isOddLot { get; set; }
        public bool isOutsideRegularHours { get; set; }
        public bool isSinglePriceCross { get; set; }
        public bool isTradeThroughExempt { get; set; }
        public long timestamp { get; set; }
    }
}