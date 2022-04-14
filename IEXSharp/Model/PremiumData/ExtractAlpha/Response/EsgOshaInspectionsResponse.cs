using System;

namespace IEXSharp.Model.PremiumData.ExtractAlpha.Response
{
	public class EsgOshaInspectionsResponse
	{
		public string EventId { get; set; }
		public string MasterName { get; set; }
		public string EstabName { get; set; }
		public string ActivityNr { get; set; }
		public string InspType { get; set; }
		public decimal updated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public DateTime Subkey { get; set; }
		public long Date { get; set; }
	}
}