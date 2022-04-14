using System;

namespace IEXSharp.Model.PremiumData.ExtractAlpha.Response
{
	public class EsgEpaEnforcementsResponse
	{
		public string EventId { get; set; }
		public string MasterName { get; set; }
		public string DefendantName { get; set; }
		public string NamedInComplaintFlag { get; set; }
		public string NamedInSettlementFlag { get; set; }
		public string ActivityId { get; set; }
		public string ActivityName { get; set; }
		public string StateCode { get; set; }
		public string RegionCode { get; set; }
		public string FiscalYear { get; set; }
		public string CaseNumber { get; set; }
		public string CaseName { get; set; }
		public string ActivityTypeCode { get; set; }
		public string ActivityTypeDesc { get; set; }
		public DateTime ActivityStatusDate { get; set; }
		public string Lead { get; set; }
		public string DojDocketNmbr { get; set; }
		public string EnfOutcomeCode { get; set; }
		public string EnfOutcomeDesc { get; set; }
		public string TotalPenaltyAssessedAmt { get; set; }
		public string TotalCostRecoveryAmt { get; set; }
		public string TotalCompActionAmt { get; set; }
		public string HqDivision { get; set; }
		public string Branch { get; set; }
		public string VoluntarySelfDisclosureFlag { get; set; }
		public string MultimediaFlag { get; set; }
		public string EnfSummaryText { get; set; }
		public decimal updated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public DateTime Subkey { get; set; }
		public long Date { get; set; }
	}
}