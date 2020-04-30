using System.ComponentModel;

namespace VSLee.IEXSharp.Model.Account.Request
{
	public enum UsageType
	{
		[Description("all")]
		All,
		[Description("messages")]
		Messages,
		[Description("rules")]
		Rules,
		[Description("rulerecords")]
		RuleRecords,
		[Description("alerts")]
		Alerts,
		[Description("alertrecords")]
		AlertRecords
	}
}