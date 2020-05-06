using System.ComponentModel;

namespace IEXSharp.Model.Options.Request
{
	public enum OptionSide
	{
		[Description("put")]
		Put,
		[Description("call")]
		Call
	}
}
