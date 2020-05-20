namespace IEXSharp.Model.PremiumData.Kavout.Response
{
	public class KavoutResponse
	{
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public string Symbol { get; set; }
		public string CompanyName { get; set; }
		public string TradeDate { get; set; }
		public decimal Kscore { get; set; }
		public decimal QualityScore { get; set; }
		public decimal GrowthScore { get; set; }
		public decimal ValueScore { get; set; }
		public decimal MomentumScore { get; set; }
		public string Date { get; set; }
		public string Updated { get; set; }
	}
}