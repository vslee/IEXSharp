using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.Shared.Response;
using VSLee.IEXSharp.Model.Stock.Request;
using System.Collections.Generic;
using IEXSharp.Model.Crypto;

namespace VSLee.IEXSharp.Service.V2.Stock
{
	public interface ISSEService
	{
		SSEClient<QuoteSSE> SubscribeStockQuoteUSSSE(IEnumerable<string> symbols, bool UTP, StockQuoteSSEInterval interval);
		SSEClient<QuoteCryptoResponse> SubscribeCryptoQuoteSSE(IEnumerable<string> symbols);
		SSEClient<EventCrypto> SubscribeCryptoEventSSE(IEnumerable<string> symbols);
	}
}
