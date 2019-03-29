using System.Collections.Generic;
using ZH.Code.IEX.V2.Model.Shared.Response;

namespace ZH.Code.IEX.V2.Model.Stock.Response
{
    public class BookResponse : Book
    {
        public Quote quote { get; set; }
        public List<Trade> trades { get; set; }
        public SystemEvent systemEvent { get; set; }
    }
}