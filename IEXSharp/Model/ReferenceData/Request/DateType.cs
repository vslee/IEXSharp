using System.ComponentModel;

namespace VSLee.IEXSharp.Model.ReferenceData.Request
{
	public enum DateType
	{
		[Description("trade")]
		Trade,
		[Description("holiday")]
		Holiday
	}
}