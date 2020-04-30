using System;

namespace IEXSharp.Model.CorporateActions.Response
{
	public class ReturnOfCapitalResponse : CorporateActionResponse
	{
		public DateTime? withdrawalFromDate { get; set; }
		public DateTime? withdrawalToDate { get; set; }
		public DateTime? electionDate { get; set; }
		public decimal cashBack { get; set; }
		public int hasWithdrawalRights { get; set; }
		public string currency { get; set; }
  }
}