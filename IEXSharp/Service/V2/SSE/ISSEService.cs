using IEXSharp.Helper;
using IEXSharp.Model.Shared.Response;
using IEXSharp.Model.Stock.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEXSharp.Service.V2.Stock
{
	public interface ISSEService
	{
		SSEClient<QuoteSSE> SubscribeStockQuoteUSSSE(IEnumerable<string> symbols, bool UTP, StockQuoteSSEInterval interval);
		SSEClient<QuoteCrypto> SubscribeCryptoQuoteSSE(IEnumerable<string> symbols);
	}
}
