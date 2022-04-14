namespace IEXSharp.Model.CoreData.StockResearch.Response
{
	public class InstitutionalOwnershipResponse
	{
		public string symbol { get; set; }
		public string id { get; set; }
		public long? adjHolding { get; set; }
		public long? adjMv { get; set; }
		public string entityProperName { get; set; }
		public long reportDate { get; set; }
		public string filingDate { get; set; }
		public long? reportedHolding { get; set; }
		public long date { get; set; }
		public decimal updated { get; set; }
	}
}