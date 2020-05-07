using IEXSharp.Helper;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.Crypto.Response;

namespace IEXSharp.Service.Cloud.Crypto
{
	internal class CryptoService : ICryptoService
	{
		private readonly ExecutorREST executor;

		public CryptoService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<CryptoBookResponse>> BookAsync(string symbol) =>
			await executor.SymbolExecuteAsync<CryptoBookResponse>("crypto/[symbol]/book", symbol);

		public async Task<IEXResponse<CryptoPriceResponse>> PriceAsync(string symbol) =>
			await executor.SymbolExecuteAsync<CryptoPriceResponse>("crypto/[symbol]/price", symbol);

		public async Task<IEXResponse<QuoteCryptoResponse>> QuoteAsync(string symbol) =>
			await executor.SymbolExecuteAsync<QuoteCryptoResponse>("crypto/[symbol]/quote", symbol);
	}
}