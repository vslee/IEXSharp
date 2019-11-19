using IEXSharp.Helper;
using IEXSharp.Model.Shared.Response;
using IEXSharp.Model.Stock.Request;
using System;
using System.Collections.Generic;

namespace IEXSharp.Service.V2.Stock
{
	internal partial class SSEService : ISSEService
	{
		readonly ExecutorSSE executorSSE;
		readonly string pk;

		public SSEService(string baseSSEURL, string sk, string pk)
		{
			this.pk = pk;
			executorSSE = new ExecutorSSE(baseSSEURL: baseSSEURL, sk: sk, pk: pk);
		}

		public SSEClient<QuoteSSE> SubscribeStockQuoteUSSSE(
			IEnumerable<string> symbols, bool UTP, StockQuoteSSEInterval interval) => UTP ?
			executorSSE.SymbolsSubscribeSSE<QuoteSSE>($"stocksUS{intervalString(interval)}", symbols, pk) :
			executorSSE.SymbolsSubscribeSSE<QuoteSSE>($"stocksUSNoUTP{intervalString(interval)}", symbols, pk);

		public SSEClient<QuoteCrypto> SubscribeCryptoQuoteSSE(IEnumerable<string> symbols) =>
			executorSSE.SymbolsSubscribeSSE<QuoteCrypto>("cryptoQuotes", symbols, pk);

		static string intervalString(StockQuoteSSEInterval interval)
		{
			switch (interval)
			{
				case StockQuoteSSEInterval.Firehose:
					return "";
				case StockQuoteSSEInterval.OneSecond:
					return "1Second";
				case StockQuoteSSEInterval.FiveSeconds:
					return "5Second";
				case StockQuoteSSEInterval.OneMinute:
					return "1Minute";
				default:
					throw new NotImplementedException();
			}
		}

		public SSEClient<EventCrypto> SubscribeCryptoEventSSE(IEnumerable<string> symbols) =>
			executorSSE.SymbolsSubscribeSSE<EventCrypto>("cryptoEvents", symbols, pk);
	}
}
