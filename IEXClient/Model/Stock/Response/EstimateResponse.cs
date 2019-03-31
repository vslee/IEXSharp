using System.Collections.Generic;

namespace IEXClient.Model.Stock.Response
{
    public class EstimateResponse
    {
        public string symbol { get; set; }
        public List<Estimate> estimates { get; set; }
    }
}