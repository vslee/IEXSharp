using System.Collections.Generic;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Model.CoreData.InvestorsExchangeData.Response
{
	public class DeepBookResponse
	{
		public List<Bid> bids { get; set; }
		public List<Ask> asks { get; set; }
	}
}