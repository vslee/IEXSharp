namespace IEXSharp.Model.CoreData.StockResearch.Response
{
	public class FundOwnershipResponse
	{
		public string symbol { get; set; }
		public long adjHolding { get; set; }
		public long? adjMv { get; set; }
		public string entityProperName { get; set; }
		public long? report_date { get; set; }
		public int reportedHolding { get; set; }
		public long reportedMv { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
		public long updated { get; set; }
	}
}