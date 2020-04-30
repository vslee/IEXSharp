using System;

namespace IEXSharp.Model.CorporateActions.Response
{
	public class DistributionResponse : CorporateActionResponse
	{
		public DateTime? withdrawalFromDate { get; set; }
		public DateTime? withdrawalToDate { get; set; }
		public DateTime? electionDate { get; set; }
		public decimal minPrice { get; set; }
		public decimal maxPrice { get; set; }
		public int hasWithdrawalRights { get; set; }
	}
}
