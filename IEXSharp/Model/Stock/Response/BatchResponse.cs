using Newtonsoft.Json;
using System.Collections.Generic;
using VSLee.IEXSharp.Model.Shared.Response;
using VSLee.IEXSharp.Model.StockFundamentals.Response;
using VSLee.IEXSharp.Model.StockPrices.Response;
using VSLee.IEXSharp.Model.StockProfiles.Response;
using VSLee.IEXSharp.Model.StockResearch.Response;

namespace VSLee.IEXSharp.Model.Stock.Response
{
	public class BatchResponse
	{
		[JsonProperty("advanced-stats")]
		public AdvancedStatsResponse AdvancedStats { get; set; }

		[JsonProperty("balance-sheet")]
		public BalanceSheetResponse BalanceSheets { get; set; }

		public BookResponse Book { get; set; }

		[JsonProperty("cash-flow")]
		public CashFlowResponse CashFlows { get; set; }

		public List<Chart> Chart { get; set; }
		public CompanyResponse Company { get; set; }

		[JsonProperty("delayed-quote")]
		public DelayedQuoteResponse DelayedQuote { get; set; }

		/// <summary> only DividendsBasic is available in batches (not DividendsAdvanced) </summary>
		[JsonProperty("dividends")]
		public List<DividendBasicResponse> DividendsBasic { get; set; }

		public EarningResponse Earnings { get; set; }

		[JsonProperty("today-earnings")]
		public List<EarningTodayResponse> EarningsToday { get; set; }

		public EstimatesResponse Estimates { get; set; }
		public FinancialResponse Financials { get; set; }

		[JsonProperty("fund-ownership")]
		public List<FundOwnershipResponse> FundOwnership { get; set; }

		[JsonProperty("income")]
		public IncomeStatementResponse IncomeStatement { get; set; }

		[JsonProperty("insider-roster")]
		public List<InsiderRosterResponse> InsiderRoster { get; set; }

		[JsonProperty("insider-summary")]
		public List<InsiderSummaryResponse> InsiderSummary { get; set; }

		[JsonProperty("insider-transactions")]
		public List<InsiderTransactionResponse> InsiderTransactions { get; set; }

		[JsonProperty("institutional-ownership")]
		public List<InstitutionalOwnershipResponse> InstitutionalOwnership { get; set; }

		[JsonProperty("intraday-prices")]
		public List<IntradayPriceResponse> IntradayPrices { get; set; }

		[JsonProperty("stats")]
		public KeyStatsResponse KeyStats { get; set; }

		[JsonProperty("largest-trades")]
		public List<LargestTradeResponse> LargestTrades { get; set; }

		public LogoResponse Logo { get; set; }
		public List<News> News { get; set; }
		public OHLCResponse Ohlc { get; set; }
		public List<string> Options { get; set; }
		public List<string> Peers { get; set; }

		[JsonProperty("previous")]
		public HistoricalPriceResponse PreviousDayPrice { get; set; }

		public decimal Price { get; set; }
		public PriceTargetResponse PriceTarget { get; set; }
		public Quote Quote { get; set; }

		[JsonProperty("recommendation-trends")]
		public List<RecommendationTrendResponse> RecommendationTrends { get; set; }

		/// <summary> only SplitsBasic is available in batches (not SplitsAdvanced) </summary>
		[JsonProperty("splits")]
		public List<SplitBasicResponse> SplitsBasic { get; set; }

		[JsonProperty("volume-by-venue")]
		public List<VolumeByVenueResponse> VolumeByVenue { get; set; }
	}
}