using System.ComponentModel;

namespace VSLee.IEXSharp.Model.Options.Request
{
	public enum OptionSide
	{
		[Description("put")]
		Put,
		[Description("call")]
		Call
	}
}