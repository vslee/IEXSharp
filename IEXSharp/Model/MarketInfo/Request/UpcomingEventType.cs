using System.ComponentModel;

namespace VSLee.IEXSharp.Model.MarketInfo.Request
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