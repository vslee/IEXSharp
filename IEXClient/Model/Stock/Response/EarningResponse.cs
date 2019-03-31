using System.Collections.Generic;
using IEXClient.Model.Shared.Response;

namespace IEXClient.Model.Stock.Response
{
    public class EarningResponse
    {
        public string symbol { get; set; }
        public List<Earning> earnings { get; set; }
    }
}