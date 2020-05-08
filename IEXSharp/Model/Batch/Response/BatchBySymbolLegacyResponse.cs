using IEXSharp.Model.News.Response;
using System.Collections.Generic;

namespace IEXSharp.Model.Batch.Response
{
	public class BatchBySymbolLegacyResponse : BatchResponse
	{
		public List<NewsLegacy> news { get; set; }
	}
}