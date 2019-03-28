using IEX.V2.Model.Shared.Response;
using System.Collections.Generic;

namespace IEX.V2.Model.Stock.Response
{
    public class EarningResponse
    {
        public string symbol { get; set; }
        public List<Earning> earnings { get; set; }
    }
}