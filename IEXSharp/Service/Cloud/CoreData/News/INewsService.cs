using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.CorporateActions.Request;
using IEXSharp.Model.CoreData.News.Response;

namespace IEXSharp.Service.Cloud.CoreData.News
{
	public interface INewsService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#news"/>
		/// </summary>
		/// <param name="symbol">A stock symbol.</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<NewsResponse>>> NewsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#news"/>
		/// </summary>
		/// <param name="symbol">A stock symbol.</param>
		/// <param name="last">Number between 1 and 50.</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<NewsResponse>>> NewsAsync(string symbol, int last);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#streaming-news"/>
		/// </summary>
		/// <param name="symbols">One or more stock symbols.</param>
		/// <returns></returns>
		SSEClient<NewsResponse> NewsStream(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#historical-news"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<NewsResponse>>> HistoricalNewsAsync(TimeSeriesRange? range = null, int? limit = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#historical-news"/>
		/// </summary>
		/// <param name="symbol">A stock symbol.</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<NewsResponse>>> HistoricalNewsAsync(string symbol, TimeSeriesRange? range = null, int? limit = null);
	}
}
