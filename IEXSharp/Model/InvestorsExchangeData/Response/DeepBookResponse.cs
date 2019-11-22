using System.Collections.Generic;
using VSLee.IEXSharp.Model.Shared.Response;

namespace VSLee.IEXSharp.Model.InvestorsExchangeData.Response
{
	public class DeepBookResponse
	{
		public List<Bid> bids { get; set; }
		public List<Ask> asks { get; set; }
	}
}