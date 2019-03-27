using System;
using System.Collections.Generic;
using System.Text;

namespace IEX.V2.Model.Stock.Response
{
    public class BatchBySymbolResponse
    {
        public BatchQuote quote { get; set; }
        public List<BatchNews> news { get; set; }
        public List<BatchChart> chart { get; set; }
    }    
}
