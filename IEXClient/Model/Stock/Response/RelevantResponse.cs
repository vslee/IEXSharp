using System.Collections.Generic;

namespace IEXClient.Model.Stock.Response
{
    public class RelevantResponse
    {
        public bool peers { get; set; }

        public IEnumerable<string> symbols { get; set; }
    }
}