using System;

namespace IEXSharp.Model.MarketInfo.Response
{
	public class UpcomingEarningEvent
	{
		public string symbol { get; set; }
		public DateTime reportDate { get; set; }
	}
}