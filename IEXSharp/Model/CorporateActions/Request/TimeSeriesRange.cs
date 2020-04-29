
using System.ComponentModel;

namespace IEXSharp.Model.CorporateActions.Request
{
	public enum TimeSeriesRange
	{
		[Description("today")]
		Today,
		[Description("yesterday")]
		Yesterday,
		[Description("tomorrow")]
		Tomorrow,
		[Description("ytd")]
		Ytd,
		[Description("1m")]
		OneMonth,
		[Description("3m")]
		ThreeMonths,
		[Description("6m")]
		SixMonths,
		[Description("1y")]
		OneYear,
		[Description("2y")]
		TwoYears,
		[Description("5y")]
		FiveYears,
		// This
		[Description("this-week")]
		ThisWeek,
		[Description("this-month")]
		ThisMonth,
		[Description("this-quarter")]
		ThisQuarter,
		// Last
		[Description("last-week")]
		LastWeek,
		[Description("last-month")]
		LastMonth,
		[Description("last-quarter")]
		LastQuarter,
		// Next
		[Description("next-week")]
		NextWeek,
		[Description("next-month")]
		NextMonth,
		[Description("next-quarter")]
		NextQuarter,
	}
}
