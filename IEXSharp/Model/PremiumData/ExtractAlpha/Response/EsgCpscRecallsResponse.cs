using System;

namespace IEXSharp.Model.PremiumData.ExtractAlpha.Response
{
	public class EsgCpscRecallsResponse
	{
		public string EventId { get; set; }
		public string MasterName { get; set; }
		public string Name { get; set; }
		public string RecallID { get; set; }
		public string RecallNumber { get; set; }
		public string Description { get; set; }
		public string URL { get; set; }
		public string Title { get; set; }
		public string ConsumerContact { get; set; }
		public DateTime LastPublishDate { get; set; }
		public decimal updated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string key { get; set; }
		public DateTime Subkey { get; set; }
		public long Date { get; set; }
	}
}