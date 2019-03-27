namespace IEX.V2.Model.Stock.Response
{
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