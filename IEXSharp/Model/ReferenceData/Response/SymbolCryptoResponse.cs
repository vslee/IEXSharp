using System;

namespace IEXSharp.Model.ReferenceData.Response
{
	public class SymbolCryptoResponse
	{
		public string symbol { get; set; }
		public string name { get; set; }
		public string exchange { get; set; }
		public DateTime date { get; set; }
		public string type { get; set; }
		public string iexId { get; set; }
		public string region { get; set; }
		public string currency { get; set; }
		public bool isEnabled { get; set; }
	}
}