using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.Batch.Request;
using IEXSharp.Model.Batch.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXSharp.Service.Cloud.Batch
{
	internal class BatchService : IBatchService
	{
		private readonly ExecutorREST executor;

		public BatchService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<BatchResponse>>
			BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types,
			string range = "", int last = 1)
		{
			if (string.IsNullOrEmpty(symbol))
			{
				throw new ArgumentNullException(nameof(symbol));
			}
			else if (types?.Count() < 1)
			{
				throw new ArgumentNullException(nameof(types));
			}

			const string urlPattern = "stock/[symbol]/batch";

			var qsType = new List<string>();
			foreach (var type in types)
			{
				qsType.Add(type.GetDescriptionFromEnum());
			}

			var qsb = new QueryStringBuilder();
			qsb.Add("types", string.Join(",", qsType));
			if (!string.IsNullOrWhiteSpace(range))
			{
				qsb.Add("range", range);
			}

			qsb.Add("last", last);

			var pathNvc = new NameValueCollection { { "symbol", symbol } };

			return await executor.ExecuteAsync<BatchResponse>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<Dictionary<string, BatchResponse>>> BatchByMarketAsync(IEnumerable<string> symbols,
			IEnumerable<BatchType> types, string range = "", int last = 1)
		{
			if (symbols?.Count() < 1)
			{
				throw new ArgumentNullException("symbols cannot be null");
			}
			else if (types?.Count() < 1)
			{
				throw new ArgumentNullException("batchTypes cannot be null");
			}

			const string urlPattern = "stock/market/batch";

			var qsType = new List<string>();
			foreach (var type in types)
			{
				qsType.Add(type.GetDescriptionFromEnum());
			}

			var qsb = new QueryStringBuilder();
			qsb.Add("symbols", string.Join(",", symbols));
			qsb.Add("types", string.Join(",", qsType));
			if (!string.IsNullOrWhiteSpace(range))
			{
				qsb.Add("range", range);
			}

			qsb.Add("last", last);

			var pathNvc = new NameValueCollection();

			return await executor.ExecuteAsync<Dictionary<string, BatchResponse>>(urlPattern, pathNvc, qsb);
		}
	}
}