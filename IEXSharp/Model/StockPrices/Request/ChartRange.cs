using System.ComponentModel;

namespace IEXSharp.Model.StockPrices.Request
{
	public enum ChartRange
	{
		[Description("date")]
		Date,
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
		[Description("max")]
		Max,
	}
}