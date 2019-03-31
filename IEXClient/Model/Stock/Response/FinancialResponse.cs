using System.Collections.Generic;
using IEXClient.Model.Shared.Response;

namespace IEXClient.Model.Stock.Response
{
    public class FinancialResponse
    {
        public string symbol { get; set; }
        public List<Financial> financials { get; set; }
    }
}