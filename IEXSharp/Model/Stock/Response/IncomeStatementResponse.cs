using System.Collections.Generic;

namespace IEXSharp.Model.Stock.Response
{
    public class IncomeStatementResponse
    {
        public string symbol { get; set; }
        public List<Income> income { get; set; }
    }

    public class Income
    {
        public string reportDate { get; set; }
        public long totalRevenue { get; set; }
        public long costOfRevenue { get; set; }
        public long grossProfit { get; set; }
        public long researchAndDevelopment { get; set; }
        public long sellingGeneralAndAdmin { get; set; }
        public long operatingExpense { get; set; }
        public long operatingIncome { get; set; }
        public long otherIncomeExpenseNet { get; set; }
        public long ebit { get; set; }
        public long interestIncome { get; set; }
        public long pretaxIncome { get; set; }
        public long incomeTax { get; set; }
        public long minorityInterest { get; set; }
        public long netIncome { get; set; }
        public long netIncomeBasic { get; set; }
    }
}