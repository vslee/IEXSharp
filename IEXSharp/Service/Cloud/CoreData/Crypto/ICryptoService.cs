using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.Crypto.Response;

namespace IEXSharp.Service.Cloud.CoreData.Crypto
{
	public interface ICryptoService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-book"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<CryptoBookResponse>> BookAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-book" and cref="https://iexcloud.io/docs/api/#sse-streaming" />
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		SSEClient<CryptoBookResponse> BookStream(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-events"/>
		/// Only accessible with SSE Streaming.
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		SSEClient<EventCrypto> EventStream(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-price"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<CryptoPriceResponse>> PriceAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-quote"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<QuoteCryptoResponse>> QuoteAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-quote"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		SSEClient<QuoteCryptoResponse> QuoteStream(IEnumerable<string> symbols);
	}
}