using System.ComponentModel;

namespace IEXSharp.Model.CoreData.ReferenceData.Request
{
	public enum DateType
	{
		[Description("trade")]
		Trade,
		[Description("holiday")]
		Holiday
	}
}