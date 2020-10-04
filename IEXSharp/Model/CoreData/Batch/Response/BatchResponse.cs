using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using IEXSharp.Model.CoreData.News.Response;
using IEXSharp.Model.CoreData.Options.Response;
using IEXSharp.Model.CoreData.StockFundamentals.Response;
using IEXSharp.Model.CoreData.StockPrices.Response;
using IEXSharp.Model.CoreData.StockProfiles.Response;
using IEXSharp.Model.CoreData.StockResearch.Response;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Model.CoreData.Batch.Response
{
	public class BatchResponse
	{
		[JsonPropertyName("advanced-stats")]
		public AdvancedStatsResponse AdvancedStats { get; set; }

		[JsonPropertyName("balance-sheet")]
		public BalanceSheetResponse BalanceSheets { get; set; }

		public BookResponse Book { get; set; }

		[JsonPropertyName("cash-flow")]
		public CashFlowsResponse CashFlows { get; set; }

		public List<Chart> Chart { get; set; }
		public CompanyResponse Company { get; set; }

		[JsonPropertyName("delayed-quote")]
		public DelayedQuoteResponse DelayedQuote { get; set; }

		/// <summary> only DividendsBasic is available in batches (not DividendsAdvanced) </summary>
		[JsonPropertyName("dividends")]
		public List<DividendBasicResponse> DividendsBasic { get; set; }

		public EarningResponse Earnings { get; set; }

		[JsonPropertyName("today-earnings")]
		public List<EarningTodayResponse> EarningsToday { get; set; }

		public EstimatesResponse Estimates { get; set; }
		public FinancialResponse Financials { get; set; }

		[JsonPropertyName("fund-ownership")]
		public List<FundOwnershipResponse> FundOwnership { get; set; }

		[JsonPropertyName("income")]
		public IncomeStatementResponse IncomeStatement { get; set; }

		[JsonPropertyName("insider-roster")]
		public List<InsiderRosterResponse> InsiderRoster { get; set; }

		[JsonPropertyName("insider-summary")]
		public List<InsiderSummaryResponse> InsiderSummary { get; set; }

		[JsonPropertyName("insider-transactions")]
		public List<InsiderTransactionResponse> InsiderTransactions { get; set; }

		[JsonPropertyName("institutional-ownership")]
		public List<InstitutionalOwnershipResponse> InstitutionalOwnership { get; set; }

		[JsonPropertyName("intraday-prices")]
		public List<IntradayPriceResponse> IntradayPrices { get; set; }

		[JsonPropertyName("stats")]
		public KeyStatsResponse KeyStats { get; set; }

		[JsonPropertyName("largest-trades")]
		public List<LargestTradeResponse> LargestTrades { get; set; }

		public LogoResponse Logo { get; set; }
		public List<NewsResponse> News { get; set; }
		public OHLCResponse Ohlc { get; set; }

		[JsonPropertyName("options")]
		public List<JsonElement> RawOptions { get; set; }

		public List<OptionResponse> OptionContracts
		{
			get
			{
				return this.RawOptions != null
					? this.RawOptions
						.Select(option => JsonSerializer.Deserialize<OptionResponse>(option.GetRawText()))
						.ToList()
					: null;
			}
		}

		public List<string> OptionExpirationDates
		{
			get
			{
				return this.RawOptions != null
					? this.RawOptions
						.Select(option => option.ToString())
						.ToList()
					: null;
			}
		}

		public List<string> Peers { get; set; }

		[JsonPropertyName("previous")]
		public HistoricalPriceResponse PreviousDayPrice { get; set; }

		public decimal Price { get; set; }
		public PriceTargetResponse PriceTarget { get; set; }
		public Quote Quote { get; set; }

		[JsonPropertyName("recommendation-trends")]
		public List<AnalystRecommendationsResponse> RecommendationTrends { get; set; }

		/// <summary> only SplitsBasic is available in batches (not SplitsAdvanced) </summary>
		[JsonPropertyName("splits")]
		public List<SplitBasicResponse> SplitsBasic { get; set; }

		[JsonPropertyName("volume-by-venue")]
		public List<VolumeByVenueResponse> VolumeByVenue { get; set; }
	}
}