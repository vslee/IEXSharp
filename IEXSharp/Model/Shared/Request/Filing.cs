using System.ComponentModel;

namespace IEXSharp.Model.Shared.Request
{
	public enum Filing
	{
		[Description("10-K")]
		Annual,
		[Description("10-Q")]
		Quarterly
	}
}