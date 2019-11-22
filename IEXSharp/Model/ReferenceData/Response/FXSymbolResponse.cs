using System.Collections.Generic;
using VSLee.IEXSharp.Model.Shared.Response;

namespace VSLee.IEXSharp.Model.ReferenceData.Response
{
	public class FXSymbolResponse
	{
		public List<Currency> currencies { get; set; }
		public List<Pair> pairs { get; set; }
	}
}