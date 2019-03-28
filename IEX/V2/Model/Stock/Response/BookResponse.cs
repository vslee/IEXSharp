using IEX.V2.Model.Shared.Response;
using System.Collections.Generic;

namespace IEX.V2.Model.Stock.Response
{
    public class BookResponse : Book
    {
        public Quote quote { get; set; }
        public List<Trade> trades { get; set; }
        public SystemEvent systemEvent { get; set; }
    }
}