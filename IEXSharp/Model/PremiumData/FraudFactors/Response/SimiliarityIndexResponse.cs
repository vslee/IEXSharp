namespace IEXSharp.Model.PremiumData.FraudFactors.Response
{
	public class SimilarityIndexResponse
	{
		public string symbol { get; set; }
		public long cik { get; set; }
		public long updated { get; set; }
		public double cosineScore { get; set; }
		public double jaccardScore { get; set; }
		public string periodDate { get; set; }
		public string filingDate { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
	}
}