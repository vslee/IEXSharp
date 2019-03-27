using System;
using System.Collections.Generic;

namespace IEX.V2.Model.Stock.Response
{
    public class EstimateResponse
    {
        public string symbol { get; set; }
        public List<Estimate> estimates { get; set; }
    }

    public class Estimate
    {
        public decimal consensusEPS { get; set; }
        public string announceTime { get; set; }
        public long numberOfEstimates { get; set; }
        public DateTime reportDate { get; set; }
        public string fiscalPeriod { get; set; }
        public DateTime fiscalEndDate { get; set; }
    }
}