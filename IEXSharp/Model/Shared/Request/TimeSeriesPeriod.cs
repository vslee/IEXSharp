using System.ComponentModel;

namespace IEXSharp.Model.Shared.Request
{
	public enum TimeSeriesPeriod
	{
		[Description("quarterly")]
		Quarterly,
		[Description("annual")]
		Annual,
		[Description("ttm")]
		Ttm
	}
}