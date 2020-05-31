using System;

namespace IEXSharp.Model.CoreData.Options.Response
{
	public class OptionResponse
	{
		// "[{\"symbol\":\"AAPL\",\"id\":\"L050CA042220300024AP2\",\"expirationDate\":\"20200419\",\"contractSize\":101,\"strikePrice\":327.4,\"closingPrice\":0.01,\"side\":\"allc\",\"type\":\"equity\",\"volume\":3,\"openInterest\":486,\"bid\":0,\"ask\":0.01,\"lastUpdated\":\"2020-04-17\",\"isAdjusted\":false}, ...]
		public string symbol { get; set; }
		public string id { get; set; }
		public string expirationDate { get; set; }
		public int contractSize { get; set; }
		public decimal strikePrice { get; set; }
		public decimal closingPrice { get; set; }
		public string side { get; set; }
		public string type { get; set; }
		public int volume { get; set; }
		public int openInterest { get; set; }
		public decimal bid { get; set; }
		public decimal ask { get; set; }
		public DateTime lastUpdated { get; set; }
		public bool isAdjusted { get; set; }
	}
}
