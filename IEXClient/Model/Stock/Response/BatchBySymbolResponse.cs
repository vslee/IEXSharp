using System.Collections.Generic;
using IEXClient.Model.Shared.Response;

namespace IEXClient.Model.Stock.Response
{
    public class BatchBySymbolResponse
    {
        public Quote quote { get; set; }
        public List<News> news { get; set; }
        public List<Chart> chart { get; set; }
    }
}