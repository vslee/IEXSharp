using System;

namespace IEXSharp.Model.CoreData.MarketInfo.Response
{
	public class UpcomingEarningEvent
	{
		public string symbol { get; set; }
		public DateTime reportDate { get; set; }
	}
}