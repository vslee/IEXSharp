namespace VSLee.IEXSharp.Model.Stock.Response
{
	public class OHLCResponse
	{
		public OHLCResponsePrice open { get; set; }
		public OHLCResponsePrice close { get; set; }
		public decimal high { get; set; }
		public decimal low { get; set; }
	}

	public class OHLCResponsePrice
	{
		public decimal price { get; set; }
		public long time { get; set; }
	}
}