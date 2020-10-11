using System.ComponentModel;

namespace IEXSharp.Model.Account.Request
{
	public enum UsageType
	{
		[Description("all")]
		All,
		[Description("messages")]
		Messages,
		[Description("rules")]
		Rules,
		[Description("rule-records")]
		RuleRecords,
		[Description("alerts")]
		Alerts,
		[Description("alert-records")]
		AlertRecords
	}
}