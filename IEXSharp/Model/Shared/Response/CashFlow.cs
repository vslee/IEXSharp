using System;

namespace IEXSharp.Model.Shared.Response
{
    public class Cashflow
    {
        public DateTime reportDate { get; set; }
        public DateTime fiscalDate { get; set; }
        public string currency { get; set; }
        public decimal? netIncome { get; set; }
        public decimal? depreciation { get; set; }
        public decimal? changesInReceivables { get; set; }
        public decimal? changesInInventories { get; set; }
        public decimal? cashChange { get; set; }
        public decimal? cashFlow { get; set; }
        public decimal? capitalExpenditures { get; set; }
        public decimal? investments { get; set; }
        public decimal? investingActivityOther { get; set; }
        public decimal? totalInvestingCashFlows { get; set; }
        public decimal? dividendsPaid { get; set; }
        public decimal? netBorrowings { get; set; }
        public decimal? otherFinancingCashFlows { get; set; }
        public decimal? cashFlowFinancing { get; set; }
        public decimal? exchangeRateEffect { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string subkey { get; set; }
        public string symbol { get; set; }
        public string filingType { get; set; }
        public int fiscalQuarter { get; set; }
        public int fiscalYear { get; set; }
        public long updated { get; set; }
    }
}