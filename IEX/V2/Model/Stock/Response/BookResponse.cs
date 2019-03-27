using System.Collections.Generic;

namespace IEX.V2.Model.Stock.Response
{
    public class BookResponse
    {
        public Quote quote { get; set; }
        public List<object> bids { get; set; }
        public List<object> asks { get; set; }
        public List<Trade> trades { get; set; }
        public SystemEvent systemEvent { get; set; }
    }

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
        public object timestamp { get; set; }
    }

    public class SystemEvent
    {
        public string systemEvent { get; set; }
        public long timestamp { get; set; }
    }
}