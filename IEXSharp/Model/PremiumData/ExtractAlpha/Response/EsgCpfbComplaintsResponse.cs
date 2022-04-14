using System;

namespace IEXSharp.Model.PremiumData.ExtractAlpha.Response
{
	public class EsgCpfbComplaintsResponse
	{
		public string EventId { get; set; }
		public string MasterName { get; set; }
		public string Company { get; set; }
		public string Product { get; set; }
		public string Subproduct { get; set; }
		public string Issue { get; set; }
		public string Subissue { get; set; }
		public string ConsumerComplaintNarrative { get; set; }
		public string CompanyPublicResponse { get; set; }
		public string ConsumerConsentProvided { get; set; }
		public DateTime DateSentToCompany { get; set; }
		public string CompanyResponseToConsumer { get; set; }
		public string TimelyResponse { get; set; }
		public string ConsumerDisputed { get; set; }
		public string ComplaintId { get; set; }
		public decimal updated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public long Date { get; set; }
	}
}