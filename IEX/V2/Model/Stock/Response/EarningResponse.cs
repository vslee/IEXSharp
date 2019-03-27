using System.Collections.Generic;

namespace IEX.V2.Model.Stock.Response
{
    public class EarningResponse
    {
        public string symbol { get; set; }
        public List<Earning> earnings { get; set; }
    }

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