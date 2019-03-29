using System.Collections.Generic;
using ZH.Code.IEX.V2.Model.Shared.Response;

namespace ZH.Code.IEX.V2.Model.Stock.Response
{
    public class EarningResponse
    {
        public string symbol { get; set; }
        public List<Earning> earnings { get; set; }
    }
}