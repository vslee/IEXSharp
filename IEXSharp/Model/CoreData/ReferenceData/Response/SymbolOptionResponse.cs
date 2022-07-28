using System;

namespace IEXSharp.Model.CoreData.ReferenceData.Response
{
	public class SymbolOptionResponse
	{
		public string symbol { get; set; }
		public DateTime date { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public DateTime expirationDate { get; set; }
		public string type { get; set; }
		public string side { get; set; }
		public string exercise { get; set; }
		public decimal strike { get; set; }
		public string underlying { get; set; }
		public string region { get; set; }
		public string currency { get; set; }
		public string figi { get; set; }
		public int contractSize { get; set; }
		public string cfiCode { get; set; }
		public string exchange { get; set; }
		public string exchangeName { get; set; }
	}
}
