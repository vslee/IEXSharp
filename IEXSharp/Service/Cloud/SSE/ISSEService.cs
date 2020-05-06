using IEXSharp.Helper;
using IEXSharp.Model.Shared.Response;
using IEXSharp.Model.Stock.Request;
using System.Collections.Generic;
using IEXSharp.Model.Crypto;

namespace IEXSharp.Service.Cloud.Stock
{
	public interface ISSEService
	{
		SSEClient<QuoteSSE> SubscribeStockQuoteUSSSE(IEnumerable<string> symbols, bool UTP, StockQuoteSSEInterval interval);
		SSEClient<QuoteCryptoResponse> SubscribeCryptoQuoteSSE(IEnumerable<string> symbols);
		SSEClient<EventCrypto> SubscribeCryptoEventSSE(IEnumerable<string> symbols);
	}
}
