using System;

namespace IEXSharp.Model.PremiumData.FraudFactors.Response
{
	public class NonTimelyFilingsResponse
	{
		public string symbol { get; set; }
		public long cik { get; set; }
		public string companyName { get; set; }
		public DateTime filingDate { get; set; }
		public string filingType { get; set; }
		public long updated { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public DateTime subkey { get; set; }
		public long date { get; set; }
	}
}