using IEX.V2.Model.Shared.Response;
using System;
using System.Collections.Generic;

namespace IEX.V2.Model.Stock.Response
{
    public class CashFlowResponse
    {
        public string symbol { get; set; }
        public List<Cashflow> cashflow { get; set; }
    }
}