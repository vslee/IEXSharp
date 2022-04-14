using System;

namespace IEXSharp.Model.PremiumData.ExtractAlpha.Response
{
	public class EsgUsptoPatentGrantsResponse
	{
		public string EventId { get; set; }
		public string MasterName { get; set; }
		public string Name1 { get; set; }
		public string Name2 { get; set; }
		public string Name3 { get; set; }
		public string PatentNumber { get; set; }
		public DateTime FilingDate { get; set; }
		public DateTime PublicationDate { get; set; }
		public decimal updated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public DateTime Subkey { get; set; }
		public long Date { get; set; }
	}
}