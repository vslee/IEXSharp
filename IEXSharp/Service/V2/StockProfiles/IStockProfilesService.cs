using IEXSharp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VSLee.IEXSharp.Model.StockProfiles.Response;

namespace IEXSharp.Service.V2.StockProfiles
{
	public interface IStockProfilesService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#company"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<CompanyResponse>> CompanyAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#insider-roster"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<InsiderRosterResponse>>> InsiderRosterAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#insider-summary"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<InsiderSummaryResponse>>> InsiderSummaryAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#insider-transactions"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<InsiderTransactionResponse>>> InsiderTransactionAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#logo"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<LogoResponse>> LogoAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#peers"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<string>>> PeersAsync(string symbol);
	}
}
