namespace IEXSharp.Model.CoreData.StockProfiles.Response
{
	public class InsiderTransactionResponse
	{
		public decimal? conversionOrExercisePrice { get; set; }
		public string directIndirect { get; set; }
		public long effectiveDate { get; set; }
		public string filingDate { get; set; }
		public string fullName { get; set; }
		public bool is10b51 { get; set; }
		public decimal? postShares { get; set; }
		public string reportedTitle { get; set; }
		public string symbol { get; set; }
		public string transactionCode { get; set; }
		public string transactionDate { get; set; }
		public decimal? transactionPrice { get; set; }
		public decimal? transactionShares { get; set; }
		public decimal? transactionValue { get; set; }
		public string id { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
		public long updated { get; set; }
		public decimal? tranPrice { get; set; }
		public decimal? tranShares { get; set; }
		public decimal? tranValue { get; set; }
	}
}