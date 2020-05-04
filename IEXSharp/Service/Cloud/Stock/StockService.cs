using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.Shared.Response;
using VSLee.IEXSharp.Model.Stock.Request;
using VSLee.IEXSharp.Model.Stock.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;

namespace VSLee.IEXSharp.Service.Cloud.Stock
{
	internal class StockService : IStockService
	{
		private readonly ExecutorREST executor;

		public StockService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<BatchResponse>>
			BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types,
			string range = "", int last = 1)
		{
			if (types?.Count() < 1)
			{
				throw new ArgumentNullException(nameof(types));
			}

			const string urlPattern = "stock/[symbol]/batch";

			var qsType = new List<string>();
			foreach (var x in types)
			{
				switch (x)
				{
					case BatchType.Quote:
						qsType.Add("quote");
						break;

					case BatchType.News:
						qsType.Add("news");
						break;

					case BatchType.Chart:
						qsType.Add("chart");
						break;

					default:
						throw new ArgumentOutOfRangeException(nameof(types));
				}
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
			if (types?.Count() < 1)
			{
				throw new ArgumentNullException("batchTypes cannot be null");
			}
			else if (symbols?.Count() < 1)
			{
				throw new ArgumentNullException("symbols cannot be null");
			}

			const string urlPattern = "stock/market/batch";

			var qsType = new List<string>();
			foreach (var x in types)
			{
				switch (x)
				{
					case BatchType.Quote:
						qsType.Add("quote");
						break;

					case BatchType.News:
						qsType.Add("news");
						break;

					case BatchType.Chart:
						qsType.Add("chart");
						break;

					default:
						throw new ArgumentOutOfRangeException(nameof(types));
				}
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

		public async Task<IEXResponse<IEnumerable<EffectiveSpreadResponse>>> EffectiveSpreadAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<EffectiveSpreadResponse>>(
				"stock/[symbol]/effective-spread", symbol);

		public async Task<IEXResponse<IEnumerable<NewsResponse>>> NewsAsync(string symbol, int last = 10) =>
			await executor.SymbolLastExecuteAsync<IEnumerable<NewsResponse>>("stock/[symbol]/news/last/[last]", symbol, last);

		public async Task<IEXResponse<IEnumerable<RecommendationTrendResponse>>> RecommendationTrendAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<RecommendationTrendResponse>>(
				"stock/[symbol]/recommendation-trends", symbol);

	}
}