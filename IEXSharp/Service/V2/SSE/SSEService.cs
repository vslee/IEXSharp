using IEXSharp.Helper;
using IEXSharp.Model.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace IEXSharp.Service.V2.Stock
{
	internal class SSEService : ISSEService
	{
		readonly ExecutorSSE executorSSE;
		readonly string pk;

		public SSEService(string baseSSEURL, string sk, string pk)
		{
			this.pk = pk;
			executorSSE = new ExecutorSSE(baseSSEURL: baseSSEURL, sk: sk, pk: pk);
		}

		public SSEClient<QuoteSSE> SubscribeQuoteSSE(IEnumerable<string> symbols, bool UTP) => UTP ?
			executorSSE.SymbolsSubscribeSSE<QuoteSSE>("stocksUS", symbols, pk) :
			executorSSE.SymbolsSubscribeSSE<QuoteSSE>("stocksUSNoUTP", symbols, pk);
	}
}
