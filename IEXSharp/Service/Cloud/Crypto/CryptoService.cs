using IEXSharp.Helper;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.Crypto.Response;
using System.Collections.Generic;

namespace IEXSharp.Service.Cloud.Crypto
{
	internal class CryptoService : ICryptoService
	{
		private readonly ExecutorREST executor;
		private readonly ExecutorSSE executorSSE;

		public CryptoService(ExecutorREST executor, ExecutorSSE executorSSE)
		{
			this.executor = executor;
			this.executorSSE = executorSSE;
		}

		public async Task<IEXResponse<CryptoBookResponse>> BookAsync(string symbol) =>
			await executor.SymbolExecuteAsync<CryptoBookResponse>("crypto/[symbol]/book", symbol);

		public async Task<IEXResponse<CryptoPriceResponse>> PriceAsync(string symbol) =>
			await executor.SymbolExecuteAsync<CryptoPriceResponse>("crypto/[symbol]/price", symbol);

		public async Task<IEXResponse<QuoteCryptoResponse>> QuoteAsync(string symbol) =>
			await executor.SymbolExecuteAsync<QuoteCryptoResponse>("crypto/[symbol]/quote", symbol);

		public SSEClient<EventCrypto> SubscribeCryptoEvents(IEnumerable<string> symbols) =>
			executorSSE.SymbolsSubscribeSSE<EventCrypto>("cryptoEvents", symbols);

		public SSEClient<QuoteCryptoResponse> SubscribeCryptoQuotes(IEnumerable<string> symbols) =>
			executorSSE.SymbolsSubscribeSSE<QuoteCryptoResponse>("cryptoQuotes", symbols);
	}
}