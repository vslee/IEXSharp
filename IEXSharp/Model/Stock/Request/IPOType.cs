using System.ComponentModel;

namespace VSLee.IEXSharp.Model.Stock.Request
{
	public enum IPOType
	{
		[Description("upcoming-ipos")]
		Upcoming,
		[Description("today-ipos")]
		Today
	}
}