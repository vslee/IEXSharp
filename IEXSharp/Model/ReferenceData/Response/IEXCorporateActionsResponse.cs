using System;
using System.Collections.Generic;
using System.Text;

namespace IEXSharp.Model.ReferenceData.Response
{
	public class IEXCorporateActionsResponse
	{
		public string RecordID { get; set; }
		public DateTime DailyListTimestamp { get; set; }
		public DateTime EffectiveDate { get; set; }
		public string IssueEvent { get; set; }
		public string CurrentSymbolinINETSymbology { get; set; }
		public string CurrentSymbolinCQSSymbology { get; set; }
		public string CurrentSymbolinCMSSymbology { get; set; }
		public string NewSymbolinINETSymbology { get; set; }
		public string NewSymbolinCQSSymbology { get; set; }
		public string NewSymbolinCMSSymbology { get; set; }
		public string CurrentSecurityName { get; set; }
		public string NewSecurityName { get; set; }
		public string CurrentCompanyName { get; set; }
		public string NewCompanyName { get; set; }
		public string CurrentListingCenter { get; set; }
		public string NewListingCenter { get; set; }
		public string DelistingReason { get; set; }
		public string CurrentRoundLotSize { get; set; }
		public string NewRoundLotSize { get; set; }
		public string CurrentLULDTierIndicator { get; set; }
		public string NewLULDTierIndicator { get; set; }
		public string ExpirationDate { get; set; }
		public string SeparationDate { get; set; }
		public string SettlementDate { get; set; }
		public string MaturityDate { get; set; }
		public string RedemptionDate { get; set; }
		public string CurrentFinancialStatus { get; set; }
		public string NewFinancialStatus { get; set; }
		public string WhenIssuedFlag { get; set; }
		public string WhenDistributedFlag { get; set; }
		public string IPOFlag { get; set; }
		public string NotesforEachEntry { get; set; }
		public DateTime RecordUpdateTime { get; set; }
	}
}
