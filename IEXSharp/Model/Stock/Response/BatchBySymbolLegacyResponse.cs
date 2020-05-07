using IEXSharp.Model.News.Response;
using IEXSharp.Model.Shared.Response;
using System.Collections.Generic;

namespace IEXSharp.Model.Stock.Response
{
	public class BatchBySymbolLegacyResponse : BatchResponse
	{
		public List<NewsLegacy> news { get; set; }
	}
}