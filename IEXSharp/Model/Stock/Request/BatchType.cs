using System.ComponentModel;

namespace VSLee.IEXSharp.Model.Stock.Request
{
	public enum BatchType
	{
		[Description("quote")]
		Quote,
		[Description("news")]
		News,
		[Description("chart")]
		Chart
	}
}