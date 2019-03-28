using System.Collections.Generic;

namespace ZH.Code.IEX.V2.Model.Stock.Response
{
    public class EstimateResponse
    {
        public string symbol { get; set; }
        public List<Estimate> estimates { get; set; }
    }
}