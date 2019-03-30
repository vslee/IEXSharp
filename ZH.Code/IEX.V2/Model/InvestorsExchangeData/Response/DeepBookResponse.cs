using System.Collections.Generic;
using ZH.Code.IEX.V2.Model.Shared.Response;

namespace ZH.Code.IEX.V2.Model.InvestorsExchangeData.Response
{
    public class DeepBookResponse
    {
        public List<Bid> bids { get; set; }
        public List<Ask> asks { get; set; }
    }
}