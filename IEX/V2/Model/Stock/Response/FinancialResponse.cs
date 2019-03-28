using IEX.V2.Model.Shared.Response;
using System;
using System.Collections.Generic;

namespace IEX.V2.Model.Stock.Response
{
    public class FinancialResponse
    {
        public string symbol { get; set; }
        public List<Financial> financials { get; set; }
    }
}