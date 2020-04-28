using System.Collections.Generic;
using VSLee.IEXSharp.Model.InvestorsExchangeData.Response;
using VSLee.IEXSharp.Model.Shared.Response;

namespace VSLee.IEXSharp.Model.StockPrices.Response
{
	public class BookResponse : DeepBookResponse
	{
		public Quote quote { get; set; }
		public List<Trade> trades { get; set; }
		public SystemEvent systemEvent { get; set; }
	}
}