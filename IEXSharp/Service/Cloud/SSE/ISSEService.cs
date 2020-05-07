using System.Collections.Generic;
using IEXSharp.Helper;
using IEXSharp.Model.Crypto.Response;
using IEXSharp.Model.Shared.Response;
using IEXSharp.Model.Stock.Request;

namespace IEXSharp.Service.Cloud.SSE
{
	public interface ISSEService
	{
		SSEClient<QuoteSSE> SubscribeStockQuoteUSSSE(IEnumerable<string> symbols, bool UTP, StockQuoteSSEInterval interval);
		SSEClient<QuoteCryptoResponse> SubscribeCryptoQuoteSSE(IEnumerable<string> symbols);
		SSEClient<EventCrypto> SubscribeCryptoEventSSE(IEnumerable<string> symbols);
	}
}
