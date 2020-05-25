using System;

namespace IEXSharp.Model.PremiumData.ExtractAlpha.Response
{
	public class EsgEpaMilestonesResponse
	{
		public string EventId { get; set; }
		public string MasterName { get; set; }
		public string DefendantName { get; set; }
		public string NamedInComplaintFlag { get; set; }
		public string NamedInSettlementFlag { get; set; }
		public string ActivityId { get; set; }
		public string CaseNumber { get; set; }
		public string SubActivityTypeCode { get; set; }
		public string SubActivityTypeDesc { get; set; }
		public long Updated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public DateTime Subkey { get; set; }
		public long Date { get; set; }
	}
}