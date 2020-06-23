namespace IEXSharp.Model.CoreData.StockProfiles.Response
{
	public class InsiderTransactionResponse
	{
		public long effectiveDate { get; set; }
		public string fullName { get; set; }
		public string reportedTitle { get; set; }
		public decimal? tranPrice { get; set; }
		public long tranShares { get; set; }
		public decimal? tranValue { get; set; }
	}
}