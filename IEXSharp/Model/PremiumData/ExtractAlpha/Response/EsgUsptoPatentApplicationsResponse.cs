using System;

namespace IEXSharp.Model.PremiumData.ExtractAlpha.Response
{
	public class EsgUsptoPatentApplicationsResponse
	{
		public string EventId { get; set; }
		public string MasterName { get; set; }
		public string OrganizationName { get; set; }
		public string AppNumber { get; set; }
		public DateTime DocumentDate { get; set; }
		public DateTime FilingDate { get; set; }
		public long Updated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public DateTime Subkey { get; set; }
		public long Date { get; set; }
	}
}