using System;
using System.ComponentModel;

namespace IEXSharp.Model.Stock.Request
{
	public enum BatchType
	{
		[Description("advanced-stats")]
		AdvancedStats,

		[Description("balance-sheet")]
		BalanceSheets,

		[Description("book")]
		Book,

		[Description("cash-flow")]
		CashFlows,

		[Description("chart")]
		Chart,

		[Description("company")]
		Company,

		[Description("delayed-quote")]
		DelayedQuote,

		/// <summary> only DividendsBasic is available in batches (not DividendsAdvanced) </summary>
		[Description("dividends")]
		DividendsBasic,

		[Description("earnings")]
		Earnings,

		[Description("today-earnings")]
		EarningsToday,

		[Description("estimates")]
		Estimates,

		[Description("financials")]
		Financials,

		[Description("fund-ownership")]
		FundOwnership,

		[Description("income")]
		IncomeStatement,

		[Description("insider-roster")]
		InsiderRoster,

		[Description("insider-summary")]
		InsiderSummary,

		[Description("insider-transactions")]
		InsiderTransactions,

		[Description("institutional-ownership")]
		InstitutionalOwnership,

		[Description("intraday-prices")]
		IntradayPrices,

		[Description("stats")]
		KeyStats,

		[Description("largest-trades")]
		LargestTrades,

		[Description("logo")]
		Logo,

		[Description("news")]
		News,

		[Description("ohlc")]
		Ohlc,

		[Description("options")]
		Options,

		[Description("peers")]
		Peers,

		[Description("previous")]
		PreviousDayPrice,

		[Description("price")]
		Price,

		[Description("price-target")]
		PriceTarget,

		[Description("quote")]
		Quote,

		[Description("recommendation-trends")]
		RecommendationTrends,

		/// <summary> only SplitsBasic is available in batches (not SplitsAdvanced) </summary>
		[Description("splits")]
		SplitsBasic,

		[Description("volume-by-venue")]
		VolumeByVenue,
	}

	public static class BatchTypeHelper
	{
		public static BatchType FromString(string name)
		{
			if (name.Equals("advanced-stats", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.AdvancedStats;

			else if (name.Equals("balance-sheet", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.BalanceSheets;

			else if (name.Equals("book", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.Book;

			else if (name.Equals("cash-flow", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.CashFlows;

			else if (name.Equals("chart", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.Chart;

			else if (name.Equals("company", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.Company;

			else if (name.Equals("delayed-quote", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.DelayedQuote;

			else if (name.Equals("dividends", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.DividendsBasic;

			else if (name.Equals("earnings", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.Earnings;

			else if (name.Equals("today-earnings", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.EarningsToday;

			else if (name.Equals("estimates", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.Estimates;

			else if (name.Equals("financials", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.Financials;

			else if (name.Equals("fund-ownership", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.FundOwnership;

			else if (name.Equals("income", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.IncomeStatement;

			else if (name.Equals("insider-roster", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.InsiderRoster;

			else if (name.Equals("insider-summary", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.InsiderSummary;

			else if (name.Equals("insider-transactions", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.InsiderTransactions;

			else if (name.Equals("institutional-ownership", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.InstitutionalOwnership;

			else if (name.Equals("intraday-prices", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.IntradayPrices;

			else if (name.Equals("stats", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.KeyStats;

			else if (name.Equals("largest-trades", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.LargestTrades;

			else if (name.Equals("logo", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.Logo;

			else if (name.Equals("news", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.News;

			else if (name.Equals("ohlc", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.Ohlc;

			else if (name.Equals("options", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.Options;

			else if (name.Equals("peers", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.Peers;

			else if (name.Equals("previous", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.PreviousDayPrice;

			else if (name.Equals("price", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.Price;

			else if (name.Equals("price-target", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.PriceTarget;

			else if (name.Equals("quote", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.Quote;

			else if (name.Equals("recommendation-trends", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.RecommendationTrends;

			else if (name.Equals("splits", StringComparison.InvariantCultureIgnoreCase))
				return BatchType.SplitsBasic;

			else
				return BatchType.VolumeByVenue;
		}
	}
}