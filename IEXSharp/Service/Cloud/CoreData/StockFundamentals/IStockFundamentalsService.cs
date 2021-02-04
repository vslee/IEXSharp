using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.StockFundamentals.Request;
using IEXSharp.Model.CoreData.StockFundamentals.Response;
using IEXSharp.Model.Shared.Request;

namespace IEXSharp.Service.Cloud.CoreData.StockFundamentals
{
	public interface IStockFundamentalsService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#advanced-fundamentals"/>
		/// Only included with paid subscription plans.
		/// Financial information is limited for some financial firms.
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="period"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<AdvancedFundamentalsResponse>>> AdvancedFundamentalsAsync(string symbol, Period period = Period.Quarter);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#balance-sheet"/>
		/// Only included with paid subscription plans.
		/// Financial information is limited for some financial firms.
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<BalanceSheetResponse>> BalanceSheetAsync(string symbol, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#balance-sheet"/>
		/// Only included with paid subscription plans.
		/// Financial information is limited for some financial firms.
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="period"></param>
		/// <param name="field"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<string>> BalanceSheetFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cash-flow"/>
		/// Only included with paid subscription plans.
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		Task<IEXResponse<CashFlowsResponse>> CashFlowAsync(string symbol, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cash-flow"/>
		/// Only included with paid subscription plans.
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		Task<IEXResponse<string>> CashFlowFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#dividends-basic"/>
		/// Dividends (Basic), as opposed to the Dividends (Advanced) found in CorporateActionsService
		/// Dividends prior to last reported are only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="range"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<DividendBasicResponse>>> DividendsBasicAsync(string symbol, DividendRange range);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#earnings"/>
		/// Earnings prior to last quarter are only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<EarningResponse>> EarningAsync(string symbol, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#earnings"/>
		/// Earnings prior to last quarter are only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<string>> EarningFieldAsync(string symbol, string field, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#financials"/>
		/// Financial Firms report financials in a different format than our 3rd party processes therefore our data is limited
		/// Only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<FinancialResponse>> FinancialAsync(string symbol, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#financials"/>
		/// Financial Firms report financials in a different format than our 3rd party processes therefore our data is limited
		/// Only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<string>> FinancialFieldAsync(string symbol, string field, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#income-statement"/>
		/// Only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<IncomeStatementResponse>> IncomeStatementAsync(string symbol, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#income-statement"/>
		/// Only included with paid subscription plans
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<string>> IncomeStatementFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#splits"/>
		/// Splits (Basic), as opposed to the Splits (Advanced) found in CorporateActionsService
		/// Splits prior to last reported are only included with paid subscription plans.
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="range"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SplitBasicResponse>>> SplitsBasicAsync(string symbol, SplitRange range = SplitRange.OneMonth);
	}
}
