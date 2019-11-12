namespace IEXSharp.Model.Stock.Response
{
    public class EffectiveSpreadResponse
    {
        public long volume { get; set; }
        public string venue { get; set; }
        public string venueName { get; set; }
        public decimal effectiveSpread { get; set; }
        public decimal effectiveQuoted { get; set; }
        public decimal priceImprovement { get; set; }
    }
}