using System.ComponentModel;

namespace VSLee.IEXSharp.Model.Stock.Request
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