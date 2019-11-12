using System.Collections.Generic;
using IEXClient.Model.Shared.Response;

namespace IEXClient.Model.Stock.Response
{
    public class CashFlowResponse
    {
        public string symbol { get; set; }
        public List<Cashflow> cashflow { get; set; }
    }
}