using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.Shared.Request;
using IEXSharp.Model.StockFundamentals.Request;
using IEXSharp.Model.StockFundamentals.Response;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXSharp.Service.Cloud.StockFundamentals
{
	public class StockFundamentalsService : IStockFundamentalsService
	{
		private readonly ExecutorREST executor;

		public StockFundamentalsService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<BalanceSheetResponse>> BalanceSheetAsync(string symbol, Period period = Period.Quarter,
			int last = 1)
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

		public async Task<IEXResponse<CashFlowResponse>> CashFlowAsync(string symbol, Period period = Period.Quarter, int last = 1)
		{
			const string urlPattern = "stock/[symbol]/cash-flow/[last]";

			var qsb = new QueryStringBuilder();
			qsb.Add("period", period.GetDescriptionFromEnum());

			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "last", last.ToString() } };

			return await executor.ExecuteAsync<CashFlowResponse>(urlPattern, pathNvc, qsb);
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

			if (range == DividendRange.Next)
			{
				var dividendResponse = await executor.ExecuteAsync<DividendBasicResponse>(urlPattern, pathNvc, qsb);

				return new IEXResponse<IEnumerable<DividendBasicResponse>>()
				{
					Data = new List<DividendBasicResponse> { dividendResponse.Data }
				};
			}

			return await executor.ExecuteAsync<IEnumerable<DividendBasicResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<EarningResponse>> EarningAsync(string symbol, int last = 1) =>
			await executor.SymbolLastExecuteAsync<EarningResponse>("stock/[symbol]/earnings/[last]", symbol, last);

		public async Task<IEXResponse<string>> EarningFieldAsync(string symbol, string field, int last = 1) =>
			await executor.SymbolLastFieldExecuteAsync("stock/[symbol]/earnings/[last]/[field]", symbol, field, last);

		public async Task<IEXResponse<FinancialResponse>> FinancialAsync(string symbol, int last = 1) =>
			await executor.SymbolLastExecuteAsync<FinancialResponse>("stock/[symbol]/financials/[last]", symbol, last);

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


			if (range == SplitRange.Next)
			{
				var splitResponse = await executor.ExecuteAsync<SplitBasicResponse>(urlPattern, pathNvc, qsb);

				return new IEXResponse<IEnumerable<SplitBasicResponse>>()
				{
					Data = new List<SplitBasicResponse> { splitResponse.Data }
				};
			}

			return await executor.ExecuteAsync<IEnumerable<SplitBasicResponse>>(urlPattern, pathNvc, qsb);
		}
	}
}
