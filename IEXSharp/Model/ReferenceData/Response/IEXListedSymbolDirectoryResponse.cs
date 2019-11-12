using System;

namespace IEXSharp.Model.ReferenceData.Response
{
    public class IEXListedSymbolDirectoryResponse
    {
        public string RecordID { get; set; }
        public DateTime DailyListTimestamp { get; set; }
        public string SymbolinINETSymbology { get; set; }
        public string SymbolinCQSSymbology { get; set; }
        public string SymbolinCMSSymbology { get; set; }
        public string SecurityName { get; set; }
        public string CompanyName { get; set; }
        public string TestIssue { get; set; }
        public string IssueDescription { get; set; }
        public string IssueType { get; set; }
        public string IssueSubType { get; set; }
        public string SICCode { get; set; }
        public string TransferAgent { get; set; }
        public string FinancialStatus { get; set; }
        public string RoundLotSize { get; set; }
        public string PreviousOfficialClosingPrice { get; set; }
        public string AdjustedPreviousOfficialClosingPrice { get; set; }
        public string WhenIssuedFlag { get; set; }
        public string WhenDistributedFlag { get; set; }
        public string IPOFlag { get; set; }
        public string FirstDateListed { get; set; }
        public string LULDTierIndicator { get; set; }
        public string CountryofIncorporation { get; set; }
        public string LeveragedETPFlag { get; set; }
        public string LeveragedETPRatio { get; set; }
        public string InverseETPFlag { get; set; }
        public DateTime RecordUpdateTime { get; set; }
    }
}