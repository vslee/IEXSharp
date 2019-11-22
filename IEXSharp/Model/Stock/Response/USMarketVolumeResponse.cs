namespace VSLee.IEXSharp.Model.Stock.Response
{
	public class USMarketVolumeResponse
	{
		public string mic { get; set; }
		public string tapeId { get; set; }
		public string venueName { get; set; }
		public long volume { get; set; }
		public long tapeA { get; set; }
		public long tapeB { get; set; }
		public long tapeC { get; set; }
		public decimal marketPercent { get; set; }
		public long? lastUpdated { get; set; }
	}
}