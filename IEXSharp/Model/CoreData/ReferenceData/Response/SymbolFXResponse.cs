using System.Collections.Generic;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Model.CoreData.ReferenceData.Response
{
	public class SymbolFXResponse
	{
		public List<Currency> currencies { get; set; }
		public List<Pair> pairs { get; set; }
	}
}