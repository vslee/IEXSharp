using System.Collections.Generic;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Model.Stock.Response
{
    public class BatchBySymbolResponse
    {
        public Quote quote { get; set; }
        public List<News> news { get; set; }
        public List<Chart> chart { get; set; }
    }
}