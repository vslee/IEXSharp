namespace VSLee.IEXSharp.Model.StockProfiles.Response
{
	public class InsiderSummaryResponse
	{
		public string fullName { get; set; }
		public long netTransacted { get; set; }
		public string reportedTitle { get; set; }
		public long totalBought { get; set; }
		public long totalSold { get; set; }
	}
}