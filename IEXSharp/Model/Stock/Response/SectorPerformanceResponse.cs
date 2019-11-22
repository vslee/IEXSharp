namespace VSLee.IEXSharp.Model.Stock.Response
{
	public class SectorPerformanceResponse
	{
		public string type { get; set; }
		public string name { get; set; }
		public decimal performance { get; set; }
		public long lastUpdated { get; set; }
	}
}