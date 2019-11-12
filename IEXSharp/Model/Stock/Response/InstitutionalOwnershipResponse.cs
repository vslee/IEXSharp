namespace IEXSharp.Model.Stock.Response
{
	public class InstitutionalOwnershipResponse
	{
		public long adjHolding { get; set; }
		public long adjMv { get; set; }
		public string entityProperName { get; set; }
		public long reportDate { get; set; }
		public long reportedHolding { get; set; }
	}
}