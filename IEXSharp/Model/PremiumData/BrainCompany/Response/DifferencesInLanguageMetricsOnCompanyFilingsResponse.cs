namespace IEXSharp.Model.PremiumData.BrainCompany.Response
{
	public class DifferencesInLanguageMetricsOnCompanyFilingsResponse
	{
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public string CalculationDate { get; set; }
		public string CompanyName { get; set; }
		public string CompositeFigi { get; set; }
		public string Symbol { get; set; }
		public string LastReportCategory { get; set; }
		public string LastReportDate { get; set; }
		public long LastReportPeriod { get; set; }
		public string PrevReportCategory { get; set; }
		public string PrevReportDate { get; set; }
		public long PrevReportPeriod { get; set; }
		public decimal DeltaSentiment { get; set; }
		public decimal DeltaScoreUncertainty { get; set; }
		public decimal DeltaScoreLitigious { get; set; }
		public decimal DeltaScoreConstraining { get; set; }
		public decimal DeltaScoreInteresting { get; set; }
		public decimal SimilarityAll { get; set; }
		public decimal SimilarityNegative { get; set; }
		public decimal SimilarityPositive { get; set; }
		public decimal SimilarityUncertainty { get; set; }
		public decimal SimilarityLitigious { get; set; }
		public decimal SimilarityConstraining { get; set; }
		public decimal SimilarityInteresting { get; set; }
		public string Updated { get; set; }
	}
}