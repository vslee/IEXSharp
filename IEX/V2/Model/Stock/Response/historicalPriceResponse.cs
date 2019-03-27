namespace IEX.V2.Model.Stock.Response
{
    public class HistoricalPriceResponse
    {
        public string date { get; set; }
        public long open { get; set; }
        public long high { get; set; }
        public long low { get; set; }
        public long close { get; set; }
        public long volume { get; set; }
        public long uOpen { get; set; }
        public long uHigh { get; set; }
        public long uLow { get; set; }
        public long uClose { get; set; }
        public long uVolume { get; set; }
        public long change { get; set; }
        public long changePercent { get; set; }
        public string label { get; set; }
        public long changeOverTime { get; set; }
    }
}