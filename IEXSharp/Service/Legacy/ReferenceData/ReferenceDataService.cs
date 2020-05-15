using IEXSharp.Helper;
using IEXSharp.Model.ReferenceData.Response;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Model;

namespace IEXSharp.Service.Legacy.ReferenceData
{
	internal class ReferenceDataService : IReferenceDataService
	{
		private readonly ExecutorREST executor;

		internal ReferenceDataService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<IEnumerable<SymbolResponse>>> SymbolsAsync() =>
			await executor.NoParamExecute<IEnumerable<SymbolResponse>>("ref-data/symbols");

		public async Task<IEXResponse<IEnumerable<IEXCorporateActionsResponse>>> IEXCorporateActionsAsync() =>
			await executor.NoParamExecute<IEnumerable<IEXCorporateActionsResponse>>("ref-data/daily-list/corporate-actions");

		public async Task<IEXResponse<IEnumerable<IEXDividendsResponse>>> IEXDividentsAsync() =>
			await executor.NoParamExecute<IEnumerable<IEXDividendsResponse>>("ref-data/daily-list/dividends");

		public async Task<IEXResponse<IEnumerable<IEXListedSymbolDirectoryResponse>>> IEXListedSymbolDirectoryAsync() =>
			await executor.NoParamExecute<IEnumerable<IEXListedSymbolDirectoryResponse>>("ref-data/daily-list/symbol-directory");

		public async Task<IEXResponse<IEnumerable<IEXNextDayExDateResponse>>> IEXNextDayExDateAsync() =>
			await executor.NoParamExecute<IEnumerable<IEXNextDayExDateResponse>>("ref-data/daily-list/next-day-ex-date");
	}
}