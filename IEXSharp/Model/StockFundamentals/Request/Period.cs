using System.ComponentModel;

namespace VSLee.IEXSharp.Model.StockFundamentals.Request
{
	public enum Period
	{
		[Description("quarter")]
		Quarter,
		[Description("annual")]
		Annual
	}
}