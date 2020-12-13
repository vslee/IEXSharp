using System.Collections.Generic;

namespace IEXSharp.Model.CoreData.StockProfiles.Response
{
	public class CompanyResponse
	{
		public string symbol { get; set; }
		public string companyName { get; set; }
		public string exchange { get; set; }
		public string industry { get; set; }
		public string website { get; set; }
		public string description { get; set; }
		public string CEO { get; set; }
		public string issueType { get; set; }
		public string sector { get; set; }
		public string primarySicCode { get; set; }
		public int employees { get; set; }
		public List<string> tags { get; set; }
		public string address { get; set; }
		public string address2 { get; set; }
		public string state { get; set; }
		public string city { get; set; }
		public string zip { get; set; }
		public string country { get; set; }
		public string phone { get; set; }
	}
}