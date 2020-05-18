using System;

namespace IEXSharp.Model.CoreData.ReferenceData.Response
{
	public class SymbolMutualFundResponse
	{
		public string symbol { get; set; }
		public string exchange { get; set; }
		public string name { get; set; }
		public DateTime date { get; set; }
		public string type { get; set; }
		public string iexId { get; set; }
		public string region { get; set; }
		public string currency { get; set; }
		public bool isEnabled { get; set; }
		public string figi { get; set; }
		public string cik { get; set; }
	}
}