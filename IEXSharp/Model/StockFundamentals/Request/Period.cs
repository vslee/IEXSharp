using System.ComponentModel;

namespace IEXSharp.Model.StockFundamentals.Request
{
	public enum Period
	{
		[Description("quarter")]
		Quarter,
		[Description("annual")]
		Annual
	}
}