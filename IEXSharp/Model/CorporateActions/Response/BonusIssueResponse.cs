
namespace IEXSharp.Model.CorporateActions.Response
{
	public class BonusIssueResponse : CorporateActionResponse
	{
		public string resultSecurityType { get; set; }
		public string currency { get; set; }
		public int lapsedPremium { get; set; }
	}
}