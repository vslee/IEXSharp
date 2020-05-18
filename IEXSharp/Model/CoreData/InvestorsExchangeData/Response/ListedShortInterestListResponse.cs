namespace IEXSharp.Model.CoreData.InvestorsExchangeData.Response
{
	public class ListedShortInterestListResponse
	{
		public string SettlementDate { get; set; }
		public string SecurityName { get; set; }
		public long CurrentShortInterest { get; set; }
		public long PreviousShortInterest { get; set; }
		public decimal PercentChange { get; set; }
		public long AverageDailyVolume { get; set; }
		public decimal DaystoCover { get; set; }
		public string StockAdjustmentFlag { get; set; }
		public string RevisionFlag { get; set; }
		public string SymbolinINETSymbology { get; set; }
		public string SymbolinCQSSymbology { get; set; }
		public string SymbolinCMSSymbology { get; set; }
		public string NewIssueFlag { get; set; }
		public string CompanyName { get; set; }
	}
}