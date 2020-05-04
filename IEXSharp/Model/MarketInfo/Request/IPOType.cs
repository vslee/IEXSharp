using System.ComponentModel;

namespace VSLee.IEXSharp.Model.MarketInfo.Request
{
	public enum IPOType
	{
		[Description("upcoming-ipos")]
		Upcoming,
		[Description("today-ipos")]
		Today
	}
}