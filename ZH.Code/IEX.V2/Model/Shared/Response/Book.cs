using System.Collections.Generic;

namespace ZH.Code.IEX.V2.Model.Shared.Response
{
    public class Book
    {
        public List<Bid> bids { get; set; }
        public List<Ask> asks { get; set; }
    }
}