using IEXSharp.Model;
using IEXSharp.Model.CoprorateActions.Request;
using IEXSharp.Model.CoprorateActions.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Helper;
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

		public async Task<IEXResponse<IEnumerable<AdvancedDividendResponse>>> DividendsAsync(
			string symbol, TimeSeriesRange range = TimeSeriesRange.ThisQuarter, bool calendar = false, int? last = null, string refId = null)
		{
			string urlPattern = "time-series/advanced_dividends/[symbol]";

			var qsb = GetQueryString(range, calendar, last, refId);
			var pathNvcTople = GetPathNvc(urlPattern, symbol);

			urlPattern = pathNvcTople.Item1;
			var pathNvc = pathNvcTople.Item2;

			return await executor.ExecuteAsync<IEnumerable<AdvancedDividendResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<PlaceholderResponse>>> BonusIssueAsync(
			string symbol, TimeSeriesRange range = TimeSeriesRange.ThisQuarter, bool calendar = false, int? last = null, string refId = null)
		{
			throw new NotImplementedException();
			// string urlPattern = "/time-series/advanced_bonus/[symbol]";
			//
			// var qsb = GetQueryString(range, calendar, last, refId);
			//
			// var pathNvcTople = GetPathNvc(urlPattern, symbol);
			// urlPattern = pathNvcTople.Item1;
			// var pathNvc = pathNvcTople.Item2;
			//
			//
			// return await executor.ExecuteAsync<IEnumerable<AdvancedDividendResponse>>(urlPattern, pathNvc, qsb);
		}

		public QueryStringBuilder GetQueryString(TimeSeriesRange range, bool calendar, int? last, string refId)
		{
			var queryStringBuilder = new QueryStringBuilder();

			queryStringBuilder.Add("range", range.GetDescription());

			if (calendar)
			{
				queryStringBuilder.Add("calendar", "true");
			}

			if (last != null)
			{
				queryStringBuilder.Add("last", last.ToString());
			}

			if (!string.IsNullOrEmpty(refId))
			{
				queryStringBuilder.Add("refId", refId);
			}

			return queryStringBuilder;
		}

		public Tuple<string, NameValueCollection> GetPathNvc(string baseUrl, string symbol)
		{
			var pathNvc = new NameValueCollection();
			if (!string.IsNullOrEmpty(symbol))
			{
				pathNvc.Add("symbol", symbol);
			}
			else
			{
				baseUrl = baseUrl.Replace("[symbol]", "");
			}

			return new Tuple<string, NameValueCollection>(baseUrl, pathNvc);
		}

		public async Task<IEXResponse<PlaceholderResponse>> DistributionAsync(string symbol, string refId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEXResponse<PlaceholderResponse>> ReturnOfCapitalAsync(string symbol, string refId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEXResponse<PlaceholderResponse>> RightsIssueAsync(string symbol, string refId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEXResponse<PlaceholderResponse>> RightToPurchaseAsync(string symbol, string refId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEXResponse<PlaceholderResponse>> SecurityReclassificationAsync(string symbol, string refId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEXResponse<PlaceholderResponse>> SecuritySwapAsync(string symbol, string refId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEXResponse<PlaceholderResponse>> SpinOffAsync(string symbol, string refId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEXResponse<PlaceholderResponse>> SplitsAsync(string symbol, string refId)
		{
			throw new NotImplementedException();
		}
	}
}
