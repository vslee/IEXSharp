using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.StockFundamentals.Request;
using IEXSharp.Model.CoreData.StockFundamentals.Response;
using IEXSharp.Model.Shared.Request;

namespace IEXSharp.Service.Cloud.CoreData.StockFundamentals
{
	public class StockFundamentalsService : IStockFundamentalsService
	{
		private readonly ExecutorREST executor;

		internal StockFundamentalsService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<IEnumerable<AdvancedFundamentalsResponse>>> AdvancedFundamentalsAsync(string symbol, TimeSeriesPeriod period = TimeSeriesPeriod.Quarterly, TimeSeries timeSeries = null)
		{
			const string urlPattern = "time-series/fundamentals/[symbol]/[period]";

			var qsb = new QueryStringBuilder();

			if (timeSeries != null)
			{
				var queryParams = timeSeries.TimeSeriesQueryParams();
				foreach (var nameValue in queryParams)
				{
					qsb.Add(nameValue.Key, nameValue.Value);
				}
			}

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol},
				{"period", period.GetDescriptionFromEnum()}
			};

			return await executor.ExecuteAsync<IEnumerable<AdvancedFundamentalsResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<BalanceSheetResponse>> BalanceSheetAsync(string symbol, Period period = Period.Quarter, int last = 1)
		{
			const string urlPattern = "stock/[symbol]/balance-sheet/[last]";

			var qsb = new QueryStringBuilder();
			qsb.Add("period", period.GetDescriptionFromEnum());

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol},
				{"last", last.ToString()}
			};

			return await executor.ExecuteAsync<BalanceSheetResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<string>> BalanceSheetFieldAsync(string symbol, string field, Period period = Period.Quarter,
			int last = 1)
		{
			const string urlPattern = "stock/[symbol]/balance-sheet/[last]/[field]";

			var qsb = new QueryStringBuilder();
			qsb.Add("period", period.GetDescriptionFromEnum());

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() }, { "field", field } };

			return await executor.ExecuteAsync<string>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<CashFlowsResponse>> CashFlowAsync(string symbol, Period period = Period.Quarter, int last = 1)
		{
			const string urlPattern = "stock/[symbol]/cash-flow/[last]";

			var qsb = new QueryStringBuilder();
			qsb.Add("period", period.GetDescriptionFromEnum());

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() } };

			return await executor.ExecuteAsync<CashFlowsResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<string>> CashFlowFieldAsync(string symbol, string field, Period period = Period.Quarter,
			int last = 1)
		{
			const string urlPattern = "stock/[symbol]/cash-flow/[last]/[field]";

			var qsb = new QueryStringBuilder();
			qsb.Add("period", period.GetDescriptionFromEnum());

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() }, { "field", field } };

			return await executor.ExecuteAsync<string>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<DividendBasicResponse>>> DividendsBasicAsync(string symbol, DividendRange range)
		{
			const string urlPattern = "stock/[symbol]/dividends/[range]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol}, {"range", range.GetDescriptionFromEnum()}
			};

			return await executor.ExecuteAsync<IEnumerable<DividendBasicResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<EarningResponse>> EarningAsync(string symbol, int last = 1) =>
			await executor.SymbolLastExecuteAsync<EarningResponse>("stock/[symbol]/earnings/[last]", symbol, last);

		public async Task<IEXResponse<string>> EarningFieldAsync(string symbol, string field, int last = 1) =>
			await executor.SymbolLastFieldExecuteAsync("stock/[symbol]/earnings/[last]/[field]", symbol, field, last);

		public async Task<IEXResponse<FinancialResponse>> FinancialAsync(string symbol, int last = 1) =>
			await executor.SymbolLastExecuteAsync<FinancialResponse>("stock/[symbol]/financials/[last]", symbol, last);

		public async Task<IEXResponse<IEnumerable<ReportedFinancialResponse>>> ReportedFinancialsAsync(string symbol, Filing filing = Filing.Quarterly, TimeSeries timeSeries = null)
		{
			const string urlPattern = "time-series/reported_financials/[symbol]/[filing]";

			var qsb = new QueryStringBuilder();

			if (timeSeries != null)
			{
				var queryParams = timeSeries.TimeSeriesQueryParams();
				foreach (var nameValue in queryParams)
				{
					qsb.Add(nameValue.Key, nameValue.Value);
				}
			}

			var pathNvc = new NameValueCollection
			{
				{"symbol", symbol},
				{"filing", filing.GetDescriptionFromEnum()}
			};

			return await executor.ExecuteAsync<IEnumerable<ReportedFinancialResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<string>> FinancialFieldAsync(string symbol, string field, int last = 1) =>
			await executor.SymbolLastFieldExecuteAsync("stock/[symbol]/financials/[last]/[field]", symbol, field, last);

		public async Task<IEXResponse<IncomeStatementResponse>> IncomeStatementAsync(string symbol, Period period = Period.Quarter,
			int last = 1)
		{
			const string urlPattern = "stock/[symbol]/income/[last]";

			var qsb = new QueryStringBuilder();
			qsb.Add("period", period.GetDescriptionFromEnum());

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() } };

			return await executor.ExecuteAsync<IncomeStatementResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<string>> IncomeStatementFieldAsync(string symbol, string field, Period period = Period.Quarter,
			int last = 1)
		{
			const string urlPattern = "stock/[symbol]/income/[last]/[field]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() }, { "field", field } };

			return await executor.ExecuteAsync<string>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<SplitBasicResponse>>> SplitsBasicAsync(string symbol, SplitRange range = SplitRange.OneMonth)
		{
			const string urlPattern = "stock/[symbol]/splits/[range]";

			var qsb = new QueryStringBuilder();

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "range", range.GetDescriptionFromEnum() } };

			return await executor.ExecuteAsync<IEnumerable<SplitBasicResponse>>(urlPattern, pathNvc, qsb);
		}
	}
}
