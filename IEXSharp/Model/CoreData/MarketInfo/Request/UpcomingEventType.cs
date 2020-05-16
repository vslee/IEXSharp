using System.ComponentModel;

namespace IEXSharp.Model.CoreData.MarketInfo.Request
{
	public enum UpcomingEventType
	{
		[Description("events")]
		Events,
		[Description("dividends")]
		Dividends,
		[Description("splits")]
		Splits,
		[Description("earnings")]
		Earnings,
		[Description("ipos")]
		IPOs
	}
}