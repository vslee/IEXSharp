using System.ComponentModel;

namespace VSLee.IEXSharp.Model.StockFundamentals.Request
{
	public enum SplitRange
	{
		[Description("next")]
		Next,
		[Description("1m")]
		OneMonth,
		[Description("3m")]
		ThreeMonths,
		[Description("6m")]
		SixMonths,
		[Description("ytd")]
		Ytd,
		[Description("1y")]
		OneYear,
		[Description("2y")]
		TwoYears,
		[Description("5y")]
		FiveYears,
	}
}