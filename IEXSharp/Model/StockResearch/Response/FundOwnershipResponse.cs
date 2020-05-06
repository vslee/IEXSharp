namespace IEXSharp.Model.StockResearch.Response
{
	public class FundOwnershipResponse
	{
		public long adjHolding { get; set; }
		public long adjMv { get; set; }
		public string entityProperName { get; set; }
		public long reportDate { get; set; }
		public long reportedHolding { get; set; }
		public long reportedMv { get; set; }
	}
}