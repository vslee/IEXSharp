using System.Collections.Generic;
using ZH.Code.IEX.V2.Model.Shared.Response;

namespace ZH.Code.IEX.V2.Model.Stock.Response
{
    public class BatchBySymbolResponse
    {
        public Quote quote { get; set; }
        public List<News> news { get; set; }
        public List<Chart> chart { get; set; }
    }
}