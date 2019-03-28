using IEX.V2.Model.Shared.Response;
using System.Collections.Generic;

namespace IEX.V2.Model.ReferenceData.Response
{
    public class FXSymbolResponse
    {
        public List<Currency> currencies { get; set; }
        public List<Pair> pairs { get; set; }
    }
}