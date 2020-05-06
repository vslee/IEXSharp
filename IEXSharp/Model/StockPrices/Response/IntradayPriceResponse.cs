namespace IEXSharp.Model.StockPrices.Response
{
	public class IntradayPriceResponse
	{
		public string date { get; set; }
		public string minute { get; set; }
		public string label { get; set; }
		public decimal marktOpen { get; set; }
		public decimal marketClose { get; set; }
		public decimal marktHigh { get; set; }
		public decimal marketLow { get; set; }
		public decimal marketAverage { get; set; }
		public long marketVolume { get; set; }
		public decimal marketNotional { get; set; }
		public long marketNumberOfTrades { get; set; }
		public decimal marketChangeOverTime { get; set; }
		public decimal high { get; set; }
		public decimal low { get; set; }
		public decimal open { get; set; }
		public decimal close { get; set; }
		public decimal average { get; set; }
		public long volume { get; set; }
		public decimal notional { get; set; }
		public long numberOfTrades { get; set; }
		public decimal changeOverTime { get; set; }
	}
}