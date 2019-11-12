using System.Collections.Generic;
using IEXClient.Model.InvestorsExchangeData.Response;
using IEXClient.Model.Shared.Response;

namespace IEXClient.Model.Stock.Response
{
    public class BookResponse : DeepBookResponse
    {
        public Quote quote { get; set; }
        public List<Trade> trades { get; set; }
        public SystemEvent systemEvent { get; set; }
    }
}