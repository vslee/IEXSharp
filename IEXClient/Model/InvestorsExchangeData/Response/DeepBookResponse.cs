using System.Collections.Generic;
using IEXClient.Model.Shared.Response;

namespace IEXClient.Model.InvestorsExchangeData.Response
{
    public class DeepBookResponse
    {
        public List<Bid> bids { get; set; }
        public List<Ask> asks { get; set; }
    }
}