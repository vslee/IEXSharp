using System;

namespace IEXSharp.Model.CoreData.CorporateActions.Response
{
	public class CorporateActionResponse
	{
		public string symbol { get; set; }
		public DateTime? exDate { get; set; }
		public DateTime? recordDate { get; set; }
		public DateTime? paymentDate { get; set; }
		public decimal fromFactor { get; set; }
		public decimal toFactor { get; set; }
		public decimal ratio { get; set; }
		public string description { get; set; }
		public string flag { get; set; }
		public string securityType { get; set; }
		public string notes { get; set; }
		public string figi { get; set; }
		public DateTime? lastUpdated { get; set; }
		public string countryCode { get; set; }
		public decimal parValue { get; set; }
		public string parValueCurrency { get; set; }
		public long? refid { get; set; }
		public DateTime? created { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long? date { get; set; }
		public long? updated { get; set; }
	}
}