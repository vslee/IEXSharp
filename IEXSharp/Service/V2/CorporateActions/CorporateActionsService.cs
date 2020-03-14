using IEXSharp.Model;
using IEXSharp.Model.CoprorateActions.Request;
using IEXSharp.Model.CoprorateActions.Response;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using VSLee.IEXSharp.Helper;

namespace IEXSharp.Service.V2.CorporateActions
{
	public class CorporateActionsService : ICorporateActionsService
	{
		private readonly string pk;
		private ExecutorREST executor;

		public CorporateActionsService(HttpClient client, string sk, string pk, bool sign)
		{
			this.pk = pk;
			this.executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<IEnumerable<AdvancedDividendResponse>>> DividendsAsync(string symbol, TimeSeriesRange range = TimeSeriesRange._this__quarter, bool calendar = false)
		{
			const string urlPattern = "time-series/advanced_dividends/[symbol]";

			var qsb = new QueryStringBuilder();
			qsb.Add("range", range.ToString().ToLower().Replace("__", "-").Replace("_", string.Empty));
			qsb.Add("calendar", calendar.ToString());

			var pathNvc = new NameValueCollection { { "symbol", symbol } };

			return await executor.ExecuteAsync<IEnumerable<AdvancedDividendResponse>>(urlPattern, pathNvc, qsb);
		}
	}
}
