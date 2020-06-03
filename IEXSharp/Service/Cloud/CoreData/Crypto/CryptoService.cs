using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.Crypto.Response;

namespace IEXSharp.Service.Cloud.CoreData.Crypto
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

		public SSEClient<CryptoBookResponse> BookStream(IEnumerable<string> symbols) =>
			executorSSE.SymbolsSubscribeSSE<CryptoBookResponse>("cryptoBook", symbols);

		public SSEClient<EventCrypto> EventStream(IEnumerable<string> symbols) =>
			executorSSE.SymbolsSubscribeSSE<EventCrypto>("cryptoEvents", symbols);

		public async Task<IEXResponse<CryptoPriceResponse>> PriceAsync(string symbol) =>
			await executor.SymbolExecuteAsync<CryptoPriceResponse>("crypto/[symbol]/price", symbol);

		public async Task<IEXResponse<QuoteCryptoResponse>> QuoteAsync(string symbol) =>
			await executor.SymbolExecuteAsync<QuoteCryptoResponse>("crypto/[symbol]/quote", symbol);

		public SSEClient<QuoteCryptoResponse> QuoteStream(IEnumerable<string> symbols) =>
			executorSSE.SymbolsSubscribeSSE<QuoteCryptoResponse>("cryptoQuotes", symbols);
	}
}