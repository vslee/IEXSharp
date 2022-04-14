using System;

namespace IEXSharp.Model.PremiumData.FraudFactors.Response
{
	public class SimilarityIndexResponse
	{
		public string symbol { get; set; }
		public long cik { get; set; }
		public decimal updated { get; set; }
		public double cosineScore { get; set; }
		public double jaccardScore { get; set; }
		public DateTime periodDate { get; set; }
		public DateTime filingDate { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public DateTime subkey { get; set; }
		public long date { get; set; }
	}
}