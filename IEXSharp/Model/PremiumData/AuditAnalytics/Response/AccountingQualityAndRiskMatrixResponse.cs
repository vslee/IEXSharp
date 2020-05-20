namespace IEXSharp.Model.PremiumData.AuditAnalytics.Response
{
	public class AccountingQualityAndRiskMatrixResponse
	{
		public string Id { get; set; }
        public string Source { get; set; }
        public string Key { get; set; }
        public string Subkey { get; set; }
        public string Symbol { get; set; }
        public long FlagYear { get; set; }
        public int AuditorRatificationSeverity { get; set; }
        public int GoingConcernSeverity { get; set; }
        public int AuditorChangeSeverity { get; set; }
        public int InternalControlsSeverity { get; set; }
        public int CeoChangeSeverity { get; set; }
        public int DisclosureControlsSeverity { get; set; }
        public int LateFilingSeverity { get; set; }
        public int PeriodAdjustmentSeverity { get; set; }
        public int MaterialImpairmentSeverity { get; set; }
        public int CfoChangeSeverity { get; set; }
        public int ShareholderActivismSeverity { get; set; }
        public int RegulatoryLitigationSeverity { get; set; }
        public int CivilRightsLitigationSeverity { get; set; }
        public int EmploymentLaborLitigationSeverity { get; set; }
        public int EnvironmentalLitigationSeverity { get; set; }
        public int IntellectualPropertyLitigationSeverity { get; set; }
        public int IllegalActivitiesLitigationSeverity { get; set; }
        public int ShareholderActionLitigationSeverity { get; set; }
        public int AccountingEstimateChangeSeverity { get; set; }
        public int FinancialRestatementSeverity { get; set; }
        public int DisclosureComplexitySeverity { get; set; }
        public int BenfordsLawSeverity { get; set; }
        public int AuditFeesChangeSeverity { get; set; }
        public int BeneishScoreSeverity { get; set; }
        public int AltmanScoreSeverity { get; set; }
        public int EngagePartnerChangeSeverity { get; set; }
        public int NonAuditFeesSeverity { get; set; }
        public int AuditFeesOutlierSeverity { get; set; }
        public long Date { get; set; }
        public long Updated { get; set; }
	}
}