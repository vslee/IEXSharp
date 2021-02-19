using System.ComponentModel;

namespace IEXSharp.Model.Shared.Request
{
	public enum TimeSeriesRange
	{
		[Description("today")]
		Today,
		[Description("yesterday")]
		Yesterday,
		[Description("ytd")]
		Ytd,
		[Description("last-week")]
		LastWeek,
		[Description("last-month")]
		LastMonth,
		[Description("last-quarter")]
		LastQuarter,
		[Description("d")]
		Days,
		[Description("w")]
		Weeks,
		[Description("m")]
		Months,
		[Description("q")]
		Quarters,
		[Description("y")]
		Years,
		[Description("tomorrow")]
		Tomorrow,
		[Description("this-week")]
		ThisWeek,
		[Description("this-month")]
		ThisMonth,
		[Description("this-quarter")]
		ThisQuarter,
		[Description("next-week")]
		NextWeek,
		[Description("next-month")]
		NextMonth,
		[Description("next-quarter")]
		NextQuarter
	}
}