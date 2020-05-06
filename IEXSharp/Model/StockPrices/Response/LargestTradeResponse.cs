namespace IEXSharp.Model.StockPrices.Response
{
	public class LargestTradeResponse
	{
		public decimal price { get; set; }
		public long size { get; set; }
		public long time { get; set; }
		public string timeLabel { get; set; }
		public string venue { get; set; }
		public string venueName { get; set; }
	}
}