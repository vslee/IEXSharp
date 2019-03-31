using System.Collections.Generic;
using IEXClient.Model.Shared.Response;

namespace IEXClient.Model.Stock.Response
{
    public class EarningTodayResponse
    {
        public List<object> bto { get; set; }
        public List<object> amc { get; set; }
        public List<Other> other { get; set; }
    }

    public class Other
    {
        public long? consensusEPS { get; set; }
        public string announceTime { get; set; }
        public long numberOfEstimates { get; set; }
        public string fiscalPeriod { get; set; }
        public string fiscalEndDate { get; set; }
        public string symbol { get; set; }
        public Quote quote { get; set; }
    }
}