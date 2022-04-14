using System;

namespace IEXSharp.Model.PremiumData.ExtractAlpha.Response
{
	public class EsgSenateLobbyingResponse
	{
		public string EventId { get; set; }
		public string MasterName { get; set; }
		public string ClientName { get; set; }
		public string Id { get; set; }
		public string Year { get; set; }
		public string Received { get; set; }
		public string Amount { get; set; }
		public decimal updated { get; set; }
		public string TemperatureId { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public DateTime Subkey { get; set; }
		public long Date { get; set; }
	}
}