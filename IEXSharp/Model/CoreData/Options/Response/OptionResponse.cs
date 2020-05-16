namespace IEXSharp.Model.CoreData.Options.Response
{
	public class OptionResponse
	{
		public string symbol { get; set; }
		public string id { get; set; }
		public int contractSize { get; set; }
		public decimal strikePrice { get; set; }
		public decimal closingPrice { get; set; }
		public string side { get; set; }
		public string type { get; set; }
		public int volume { get; set; }
		public int openInterest { get; set; }
		public decimal bid { get; set; }
		public decimal ask { get; set; }
		public string lastUpdated { get; set; }
		public bool isAdjusted { get; set; }
	}
}
