using System.Collections.Generic;
using ZH.Code.IEX.V2.Model.Shared.Response;

namespace ZH.Code.IEX.V2.Model.ReferenceData.Response
{
    public class FXSymbolResponse
    {
        public List<Currency> currencies { get; set; }
        public List<Pair> pairs { get; set; }
    }
}