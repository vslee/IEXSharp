using System;
using System.Collections.Generic;

namespace IEX.V2.Model.Stock.Response
{
    public class FinancialResponse
    {
        public string symbol { get; set; }
        public List<Financial> financials { get; set; }
    }

    public class Financial
    {
        public DateTime reportDate { get; set; }
        public long grossProfit { get; set; }
        public long costOfRevenue { get; set; }
        public long operatingRevenue { get; set; }
        public long totalRevenue { get; set; }
        public long operatingIncome { get; set; }
        public long netIncome { get; set; }
        public long researchAndDevelopment { get; set; }
        public long operatingExpense { get; set; }
        public long currentAssets { get; set; }
        public long totalAssets { get; set; }
        public long totalLiabilities { get; set; }
        public long currentCash { get; set; }
        public long currentDebt { get; set; }
        public long totalCash { get; set; }
        public long totalDebt { get; set; }
        public long shareholderEquity { get; set; }
        public int cashChange { get; set; }
        public long cashFlow { get; set; }
        public string operatingGainsLosses { get; set; }
    }
}