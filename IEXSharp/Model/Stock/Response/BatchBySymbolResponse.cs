using System.Collections.Generic;
using VSLee.IEXSharp.Model.Shared.Response;
using VSLee.IEXSharp.Model.StockFundamentals.Response;
using VSLee.IEXSharp.Model.StockPrices.Response;
using VSLee.IEXSharp.Model.StockProfiles.Response;

namespace VSLee.IEXSharp.Model.Stock.Response
{
	public class BatchResponse
	{
		//public AdvancedStats AdvancedStats { get; set; } - not implemented yet
		public BalanceSheetResponse BalanceSheets { get; set; }
		public BookResponse Book { get; set; }
		public CashFlowResponse CashFlows { get; set; }
		public List<Chart> Chart { get; set; }
		public CompanyResponse Company { get; set; }
		public DelayedQuoteResponse DelayedQuote { get; set; }
		public List<DividendResponse> Dividends { get; set; }
		public EarningResponse Earnings { get; set; }
		public EarningTodayResponse EarningsToday { get; set; }
		public EstimateResponse Estimates { get; set; }
		public FinancialResponse Financials { get; set; }
		public List<FundOwnershipResponse> FundOwnership { get; set; }
		public IncomeStatementResponse IncomeStatements { get; set; }
		public List<InsiderRosterResponse> InsiderRoster { get; set; }
		public List<InsiderSummaryResponse> InsiderSummary { get; set; }
		public List<InsiderTransactionResponse> InsiderTransaction { get; set; }
		public List<InstitutionalOwnershipResponse> InstitutionalOwnership { get; set; }
		public List<IntradayPriceResponse> IntradayPrices { get; set; }
		public KeyStatsResponse KeyStats { get; set; }
		public List<LargestTradeResponse> LargestTrades { get; set; }
		public LogoResponse Logo { get; set; }
		public List<News> News { get; set; }
		public OHLCResponse Ohlc { get; set; }
		public List<string> Options { get; set; }
		public List<string> Peers { get; set; }
		//public BarData Previous { get; set; } - not implemented yet
		public decimal Price { get; set; }
		public PriceTargetResponse PriceTarget { get; set; }
		public Quote Quote { get; set; }
		public List<RecommendationTrendResponse> RecommendationTrends { get; set; }
		public List<Split> Splits { get; set; }
		public List<VolumeByVenueResponse> VolumeByVenue { get; set; }
	}
}