using System;

namespace IEXSharp.Model.PremiumData.BrainCompany.Response
{
	public class LanguageMetricsOnCompanyFilingsResponse
	{
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public DateTime Subkey { get; set; }
		public DateTime CalculationDate { get; set; }
		public string CompanyName { get; set; }
		public string CompositeFigi { get; set; }
		public string Symbol { get; set; }
		public string LastReportCategory { get; set; }
		public DateTime? LastReportDate { get; set; }
		public decimal Sentiment { get; set; }
		public decimal ScoreUncertainty { get; set; }
		public decimal ScoreLitigious { get; set; }
		public decimal ScoreConstraining { get; set; }
		public decimal ScoreInteresting { get; set; }
		public string Updated { get; set; }
	}
}