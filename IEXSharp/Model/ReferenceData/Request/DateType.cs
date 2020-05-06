using System.ComponentModel;

namespace IEXSharp.Model.ReferenceData.Request
{
	public enum DateType
	{
		[Description("trade")]
		Trade,
		[Description("holiday")]
		Holiday
	}
}