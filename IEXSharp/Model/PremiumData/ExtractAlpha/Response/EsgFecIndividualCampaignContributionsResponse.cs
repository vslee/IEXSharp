using System;

namespace IEXSharp.Model.PremiumData.ExtractAlpha.Response
{
	public class EsgFecIndividualCampaignContributionsResponse
	{
		public string EventId { get; set; }
		public string MasterName { get; set; }
		public string Employer { get; set; }
		public string AmndInd { get; set; }
		public string TransactionAmt { get; set; }
		public string TranId { get; set; }
		public string FileNum { get; set; }
		public decimal updated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public DateTime Subkey { get; set; }
		public long Date { get; set; }
	}
}