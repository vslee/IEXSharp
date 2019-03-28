namespace ZH.Code.IEX.V2.Model.InvestorsExchangeData.Response
{
    public class StatsRecentResponse
    {
        public string date { get; set; }
        public long volume { get; set; }
        public long routedVolume { get; set; }
        public decimal marketShare { get; set; }
        public bool isHalfday { get; set; }
        public long litVolume { get; set; }
    }
}