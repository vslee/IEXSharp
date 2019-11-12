using System.Collections.Generic;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Model.Stock.Response
{
    public class EarningResponse
    {
        public string symbol { get; set; }
        public List<Earning> earnings { get; set; }
    }
}