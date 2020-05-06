using System;
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

	public static class ChartRangeHelper
	{
		public static ChartRange FromString(string name)
		{
			if (name.Equals("date", StringComparison.InvariantCultureIgnoreCase))
				return ChartRange.Date;
			else if (name.Equals("1m", StringComparison.InvariantCultureIgnoreCase))
				return ChartRange.OneMonth;
			else if (name.Equals("3m", StringComparison.InvariantCultureIgnoreCase))
				return ChartRange.ThreeMonths;
			else if (name.Equals("6m", StringComparison.InvariantCultureIgnoreCase))
				return ChartRange.SixMonths;
			else if (name.Equals("ytd", StringComparison.InvariantCultureIgnoreCase))
				return ChartRange.Ytd;
			else if (name.Equals("1y", StringComparison.InvariantCultureIgnoreCase))
				return ChartRange.OneYear;
			else if (name.Equals("2y", StringComparison.InvariantCultureIgnoreCase))
				return ChartRange.TwoYears;
			else if (name.Equals("5y", StringComparison.InvariantCultureIgnoreCase))
				return ChartRange.FiveYears;
			else
				return ChartRange.Max;
		}
	}
}