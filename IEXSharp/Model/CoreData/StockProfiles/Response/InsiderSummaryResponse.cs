namespace IEXSharp.Model.CoreData.StockProfiles.Response
{
	public class InsiderSummaryResponse
	{
		public string fullName { get; set; }
		public long netTransacted { get; set; }
		public string reportedTitle { get; set; }
		public string symbol { get; set; }
		public long totalBought { get; set; }
		public long totalSold { get; set; }
		public string id { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public decimal updated { get; set; }
	}
}