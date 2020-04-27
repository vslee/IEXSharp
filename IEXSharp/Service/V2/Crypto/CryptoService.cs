using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.Shared.Response;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Model;

namespace VSLee.IEXSharp.Service.V2.Crypto
{
	internal class CryptoService : ICryptoService
	{
		private readonly ExecutorREST executor;

		public CryptoService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public Task<IEXResponse<Quote>> BookAsync(string symbol)
		{
			throw new NotImplementedException();
		}

		public Task<IEXResponse<Quote>> PriceAsync(string symbol)
		{
			throw new NotImplementedException();
		}

		public async Task<IEXResponse<Quote>> QuoteAsync(string symbol) =>
			await executor.SymbolExecuteAsync<Quote>("crypto/[symbol]/quote", symbol);
	}
}