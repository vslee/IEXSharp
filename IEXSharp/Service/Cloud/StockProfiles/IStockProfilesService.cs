using IEXSharp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IEXSharp.Model.StockProfiles.Response;

namespace IEXSharp.Service.Cloud.StockProfiles
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
		/// Only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<InsiderRosterResponse>>> InsiderRosterAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#insider-summary"/>
		/// Only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<InsiderSummaryResponse>>> InsiderSummaryAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#insider-transactions"/>
		/// Only included with paid subscription plans
		/// Insider transactions for the last 12 months on a rolling basis
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<InsiderTransactionResponse>>> InsiderTransactionsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#logo"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<LogoResponse>> LogoAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#peers"/>
		/// Only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<string>>> PeerGroupsAsync(string symbol);
	}
}
