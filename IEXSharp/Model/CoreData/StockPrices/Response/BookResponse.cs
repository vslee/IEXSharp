using System.Collections.Generic;
using IEXSharp.Model.CoreData.InvestorsExchangeData.Response;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Model.CoreData.StockPrices.Response
{
	public class BookResponse : DeepBookResponse
	{
		public Quote quote { get; set; }
		public List<Trade> trades { get; set; }
		public SystemEvent systemEvent { get; set; }
	}
}