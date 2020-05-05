using System.ComponentModel;

namespace VSLee.IEXSharp.Model.Stock.Request
{
	public enum BatchType
	{
		[Description("advanced-stats")]
		AdvancedStats,

		[Description("balance-sheet")]
		BalanceSheet,

		[Description("book")]
		Book,

		[Description("cash-flow")]
		CashFlow,

		[Description("chart")]
		Chart,

		[Description("company")]
		Company,

		[Description("delayed-quote")]
		DelayedQuote,

		[Description("dividends")]
		Dividends,

		[Description("earnings")]
		Earnings,

		[Description("today-earnings")]
		TodayEarnings,

		[Description("estimates")]
		Estimates,

		[Description("financials")]
		Financials,

		[Description("fund-ownership")]
		FundOwnership,

		[Description("income")]
		Income,

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
		Previous,

		[Description("price")]
		Price,

		[Description("price-target")]
		PriceTarget,

		[Description("quote")]
		Quote,

		[Description("recommendation-trends")]
		RecommendationTrends,

		[Description("splits")]
		Splits,

		[Description("volume-by-venue")]
		VolumeByVenue,
	}
}