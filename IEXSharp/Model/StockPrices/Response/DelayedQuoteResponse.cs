namespace IEXSharp.Model.StockPrices.Response
{
	public class DelayedQuoteResponse
	{
		public string symbol { get; set; }
		public decimal delayedPrice { get; set; }
		public long delayedSize { get; set; }
		public long delayedPriceTime { get; set; }
		public decimal high { get; set; }
		public decimal low { get; set; }
		public long totalVolume { get; set; }
		public long processedTime { get; set; }
	}
}