using System.Collections.Generic;

namespace IEX.V2.Model.Stock.Response
{
    public class BatchBySymbolResponse
    {
        public Quote quote { get; set; }
        public List<BatchNews> news { get; set; }
        public List<BatchChart> chart { get; set; }
    }
}