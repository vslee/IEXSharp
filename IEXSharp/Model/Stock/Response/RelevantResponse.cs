using System.Collections.Generic;

namespace IEXSharp.Model.Stock.Response
{
	public class RelevantResponse
	{
		public bool peers { get; set; }

		public IEnumerable<string> symbols { get; set; }
	}
}