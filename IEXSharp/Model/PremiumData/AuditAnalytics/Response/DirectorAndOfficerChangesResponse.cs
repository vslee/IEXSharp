using System;

namespace IEXSharp.Model.PremiumData.AuditAnalytics.Response
{
	public class DirectorAndOfficerChangesResponse
	{
		public string Id { get; set; }
        public string Source { get; set; }
        public string Key { get; set; }
        public string Subkey { get; set; }
        public string Symbol { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string TitleAsReported { get; set; }
        public int IsCLevel { get; set; }
        public int IsBoardmemberPerson { get; set; }
        public int IsScienceTechPerson { get; set; }
        public int IsLegal { get; set; }
        public int IsAdministrativePerson { get; set; }
        public int IsFinancialPerson { get; set; }
        public int IsOperationsPerson { get; set; }
        public int IsController { get; set; }
        public int IsCharimanOfBoard { get; set; }
        public int IsCharimanOther { get; set; }
        public int IsSecretary { get; set; }
        public int IsCoo { get; set; }
        public int IsPresident { get; set; }
        public int IsCeo { get; set; }
        public int IsCfo { get; set; }
        public int IsExecOrSrVp { get; set; }
        public int TitleStandardized { get; set; }
        public int CommitteesAsReported { get; set; }
        public int CommitteesStandardized { get; set; }
        public int Interim { get; set; }
        public int DirectorOfficerRemainsOnBoard { get; set; }
        public int ReatainsOtherPositions { get; set; }
        public int EffectiveDateIsUnspecified { get; set; }
        public int IsEffectiveOnDateOfNextAnnualMeeting { get; set; }
        public string Action { get; set; }
        public string Reasons { get; set; }
        public string EmploymentEducationText { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string NameSuffix { get; set; }
        public string DegreesSuffix { get; set; }
        public string ApproxYob { get; set; }
        public string SubsidiaryName { get; set; }
        public string DirectorOfficerChangeText { get; set; }
        public string FtpFileNameFkey { get; set; }
        public string FormFkey { get; set; }
        public DateTime FileDate { get; set; }
        public string FileSize { get; set; }
        public DateTime FileAccepted { get; set; }
        public string HttpFileNameHtml { get; set; }
        public string HttpFileNameText { get; set; }
        public long Date { get; set; }
        public long Updated { get; set; }
	}
}