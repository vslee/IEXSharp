using System;

namespace IEXSharp.Model.CorporateActions.Response
{
	public class RightToPurchaseResponse : CorporateActionResponse
	{
		public DateTime? subscriptionStart { get; set; }
		public DateTime? subscriptionEnd { get; set; }
		public double issuePrice { get; set; }
		public string resultSecurityType { get; set; }
		public int isOverSubscription { get; set; }
		public string currency { get; set; }
	}
}