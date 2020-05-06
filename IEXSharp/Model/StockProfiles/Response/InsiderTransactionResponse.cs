namespace IEXSharp.Model.StockProfiles.Response
{
	public class InsiderTransactionResponse
	{
		public long effectiveDate { get; set; }
		public string fullName { get; set; }
		public string reportedTitle { get; set; }
		public long tranPrice { get; set; }
		public long tranShares { get; set; }
		public long tranValue { get; set; }
	}
}