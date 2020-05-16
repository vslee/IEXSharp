using System.Collections.Generic;
using IEXSharp.Model.CoreData.News.Response;

namespace IEXSharp.Model.CoreData.Batch.Response
{
	public class BatchBySymbolLegacyResponse : BatchResponse
	{
		public List<NewsLegacy> news { get; set; }
	}
}