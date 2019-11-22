using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.Shared.Response;
using VSLee.IEXSharp.Model.Stock.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace VSLee.IEXSharp.Service.V2.Stock
{
	public interface ISSEService
	{
		SSEClient<QuoteSSE> SubscribeStockQuoteUSSSE(IEnumerable<string> symbols, bool UTP, StockQuoteSSEInterval interval);
		SSEClient<QuoteCrypto> SubscribeCryptoQuoteSSE(IEnumerable<string> symbols);
		SSEClient<EventCrypto> SubscribeCryptoEventSSE(IEnumerable<string> symbols);
	}
}
