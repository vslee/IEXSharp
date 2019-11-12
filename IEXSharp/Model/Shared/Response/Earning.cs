namespace IEXSharp.Model.Shared.Response
{
    public class Earning
    {
        public decimal actualEPS { get; set; }
        public decimal consensusEPS { get; set; }
        public string announceTime { get; set; }
        public int numberOfEstimates { get; set; }
        public decimal EPSSurpriseDollar { get; set; }
        public string EPSReportDate { get; set; }
        public string fiscalPeriod { get; set; }
        public string fiscalEndDate { get; set; }
        public decimal yearAgo { get; set; }
        public decimal yearAgoChangePercent { get; set; }
    }
}