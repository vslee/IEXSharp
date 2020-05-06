using IEXSharp.Model;
using System.Threading.Tasks;
using IEXSharp.Model.Crypto;
using IEXSharp.Model.Shared.Response;

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
	}
}