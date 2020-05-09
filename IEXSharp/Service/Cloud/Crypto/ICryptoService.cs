using IEXSharp.Model;
using System.Threading.Tasks;
using IEXSharp.Model.Crypto.Response;
using IEXSharp.Helper;
using System.Collections.Generic;

namespace IEXSharp.Service.Cloud.Crypto
{
	public interface ICryptoService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-book"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<CryptoBookResponse>> BookAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-events"/>
		/// Only accessible with SSE Streaming.
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		SSEClient<EventCrypto> SubscribeCryptoEvents(IEnumerable<string> symbols);

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
		/// <param name="symbol"></param>
		/// <returns></returns>
		SSEClient<QuoteCryptoResponse> SubscribeCryptoQuotes(IEnumerable<string> symbols);
	}
}