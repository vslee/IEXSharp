using System.Collections.Generic;
using IEXClient.Model.Shared.Response;

namespace IEXClient.Model.ReferenceData.Response
{
    public class FXSymbolResponse
    {
        public List<Currency> currencies { get; set; }
        public List<Pair> pairs { get; set; }
    }
}