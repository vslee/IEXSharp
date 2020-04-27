using IEXSharp.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSLee.IEXSharp.Model.AlternativeData.Response;
using VSLee.IEXSharp.Model.Shared.Response;

namespace VSLee.IEXSharp.Service.V2.Crypto
{
	public interface ICryptoService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-book"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<Quote>> BookAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-price"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<Quote>> PriceAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cryptocurrency-quote"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<Quote>> QuoteAsync(string symbol);
	}
}