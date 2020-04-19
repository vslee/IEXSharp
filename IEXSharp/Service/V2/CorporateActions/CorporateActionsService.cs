using IEXSharp.Model;
using IEXSharp.Model.CoprorateActions.Request;
using IEXSharp.Model.CoprorateActions.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using VSLee.IEXSharp.Helper;

namespace IEXSharp.Service.V2.CorporateActions
{
	public class CorporateActionsService : ICorporateActionsService
	{
		private ExecutorREST executor;

		public CorporateActionsService(HttpClient client, string sk, string pk, bool sign)
		{
			executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<IEnumerable<AdvancedDividendResponse>>> DividendsAsync(string symbol,
			TimeSeriesRange range = TimeSeriesRange._this__quarter, bool calendar = false, int? last = null, string refid = null)
		{
			if (symbol == null)
				throw new ArgumentNullException("Support for calls without symbol is not yet supported. Please submit a pull request on GitHub if you would like to add it.");
			if (calendar)
				throw new ArgumentException("Support for 'calendar' parameter is not yet supported. Please submit a pull request on GitHub if you would like to add it.");
			if (last != null)
				throw new ArgumentException("Support for 'last' parameter is not yet supported. Please submit a pull request on GitHub if you would like to add it.");
			if (refid != null)
				throw new ArgumentException("Support for 'refid' parameter is not yet supported. Please submit a pull request on GitHub if you would like to add it.");

			const string urlPattern = "time-series/advanced_dividends/[symbol]";

			var qsb = new QueryStringBuilder();
			qsb.Add("range", range.ToString().ToLower().Replace("__", "-").Replace("_", string.Empty));

			var pathNvc = new NameValueCollection { { "symbol", symbol } };

			return await executor.ExecuteAsync<IEnumerable<AdvancedDividendResponse>>(urlPattern, pathNvc, qsb);
		}
	}
}
