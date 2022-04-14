using System;

namespace IEXSharp.Model.PremiumData.Kavout.Response
{
	public class KavoutResponse
	{
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public DateTime Subkey { get; set; }
		public string Symbol { get; set; }
		public string CompanyName { get; set; }
		public DateTime TradeDate { get; set; }
		public decimal Kscore { get; set; }
		public decimal QualityScore { get; set; }
		public decimal GrowthScore { get; set; }
		public decimal ValueScore { get; set; }
		public decimal MomentumScore { get; set; }
		public long Date { get; set; }
		public decimal updated { get; set; }
	}
}