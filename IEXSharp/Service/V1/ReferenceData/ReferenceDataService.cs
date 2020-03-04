using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.ReferenceData.Response;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace VSLee.IEXSharp.Service.V1.ReferenceData
{
	internal class ReferenceDataService : IReferenceDataService
	{
		private readonly ExecutorREST _executor;

		public ReferenceDataService(HttpClient client)
		{
			_executor = new ExecutorREST(client, "", "", false);
		}

		public async Task<IEnumerable<SymbolResponse>> SymbolsAsync() => await _executor.NoParamExecuteLegacy<IEnumerable<SymbolResponse>>("ref-data/symbols");

		public async Task<IEnumerable<IEXCorporateActionsResponse>> IEXCorporateActionsAsync()
			=> await _executor.NoParamExecuteLegacy<IEnumerable<IEXCorporateActionsResponse>>("ref-data/daily-list/corporate-actions");

		public async Task<IEnumerable<IEXDividendsResponse>> IEXDividentsAsync()
			=> await _executor.NoParamExecuteLegacy<IEnumerable<IEXDividendsResponse>>("ref-data/daily-list/dividends");

		public async Task<IEnumerable<IEXListedSymbolDirectoryResponse>> IEXListedSymbolDirectoryAsync()
			=> await _executor.NoParamExecuteLegacy<IEnumerable<IEXListedSymbolDirectoryResponse>>("ref-data/daily-list/symbol-directory");

		public async Task<IEnumerable<IEXNextDayExDateResponse>> IEXNextDayExDateAsync()
			=> await _executor.NoParamExecuteLegacy<IEnumerable<IEXNextDayExDateResponse>>("ref-data/daily-list/next-day-ex-date");
	}
}