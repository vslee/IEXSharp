using System;

namespace IEXSharp.Model.CoreData.CorporateActions.Response
{
	public class RightsIssueResponse : CorporateActionResponse
	{
		public DateTime? subscriptionStartDate { get; set; }
		public DateTime? subscriptionEndDate { get; set; }
		public DateTime? tradeStartDate { get; set; }
		public DateTime? tradeEndDate { get; set; }
		public DateTime? splitDate { get; set; }
		public string resultSecurityType { get; set; }
		public string currency { get; set; }
		public decimal issuePrice { get; set; }
		public int lapsedPremium { get; set; }
		public int isOverSubscription { get; set; }
	}
}