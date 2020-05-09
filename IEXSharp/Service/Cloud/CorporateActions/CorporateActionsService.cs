using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CorporateActions.Request;
using IEXSharp.Model.CorporateActions.Response;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXSharp.Service.Cloud.CorporateActions
{
	public class CorporateActionsService : ICorporateActionsService
	{
		private ExecutorREST executor;

		public CorporateActionsService(HttpClient client, string publishableToken, string secretToken, bool sign)
		{
			executor = new ExecutorREST(client, publishableToken, secretToken, sign);
		}

		public async Task<IEXResponse<IEnumerable<BonusIssueResponse>>> BonusIssueAsync(
			string symbol, TimeSeriesRange? range, bool calendar = false, int? last = null, string refId = null)
		{
			string urlPattern = "time-series/advanced_bonus/[symbol]";
			urlPattern = GetBaseUrl(urlPattern, symbol);
			var qsb = GetQueryString(range, calendar, last, refId);
			var pathNvc = GetPathNvc(symbol);

			return await executor.ExecuteAsync<IEnumerable<BonusIssueResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<DistributionResponse>>> DistributionAsync(
			string symbol, TimeSeriesRange? range, bool calendar = false, int? last = null, string refId = null)
		{
			string urlPattern = "time-series/advanced_distribution/[symbol]";
			urlPattern = GetBaseUrl(urlPattern, symbol);
			var qsb = GetQueryString(range, calendar, last, refId);
			var pathNvc = GetPathNvc(symbol);

			return await executor.ExecuteAsync<IEnumerable<DistributionResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<DividendAdvancedResponse>>> DividendsAdvancedAsync(
			string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId)
		{
			string urlPattern = "time-series/advanced_dividends/[symbol]";
			urlPattern = GetBaseUrl(urlPattern, symbol);
			var qsb = GetQueryString(range, calendar, last, refId);
			var pathNvc = GetPathNvc(symbol);

			return await executor.ExecuteAsync<IEnumerable<DividendAdvancedResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<ReturnOfCapitalResponse>>> ReturnOfCapitalAsync(
			string symbol, TimeSeriesRange? range, bool calendar = false, int? last = null, string refId = null)
		{
			string urlPattern = "time-series/advanced_return_of_capital/[symbol]";
			urlPattern = GetBaseUrl(urlPattern, symbol);
			var qsb = GetQueryString(range, calendar, last, refId);
			var pathNvc = GetPathNvc(symbol);

			return await executor.ExecuteAsync<IEnumerable<ReturnOfCapitalResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<RightsIssueResponse>>> RightsIssueAsync(
			string symbol, TimeSeriesRange? range, bool calendar = false, int? last = null, string refId = null)
		{
			string urlPattern = "time-series/advanced_rights/[symbol]";
			urlPattern = GetBaseUrl(urlPattern, symbol);
			var qsb = GetQueryString(range, calendar, last, refId);
			var pathNvc = GetPathNvc(symbol);

			return await executor.ExecuteAsync<IEnumerable<RightsIssueResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<RightToPurchaseResponse>>> RightToPurchaseAsync(
			string symbol, TimeSeriesRange? range, bool calendar = false, int? last = null, string refId = null)
		{
			string urlPattern = "time-series/advanced_right_to_purchase/[symbol]";
			urlPattern = GetBaseUrl(urlPattern, symbol);
			var qsb = GetQueryString(range, calendar, last, refId);
			var pathNvc = GetPathNvc(symbol);

			return await executor.ExecuteAsync<IEnumerable<RightToPurchaseResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<SecurityUpdateResponse>>> SecurityReclassificationAsync(
			string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId)
		{
			string urlPattern = "time-series/advanced_security_reclassification/[symbol]";
			urlPattern = GetBaseUrl(urlPattern, symbol);
			var qsb = GetQueryString(range, calendar, last, refId);
			var pathNvc = GetPathNvc(symbol);

			return await executor.ExecuteAsync<IEnumerable<SecurityUpdateResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<SecurityUpdateResponse>>> SecuritySwapAsync(
			string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId)
		{
			string urlPattern = "time-series/advanced_security_swap/[symbol]";
			urlPattern = GetBaseUrl(urlPattern, symbol);
			var qsb = GetQueryString(range, calendar, last, refId);
			var pathNvc = GetPathNvc(symbol);

			return await executor.ExecuteAsync<IEnumerable<SecurityUpdateResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<SpinOffResponse>>> SpinOffAsync(
			string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId)
		{
			string urlPattern = "time-series/advanced_spinoff/[symbol]";
			urlPattern = GetBaseUrl(urlPattern, symbol);
			var qsb = GetQueryString(range, calendar, last, refId);
			var pathNvc = GetPathNvc(symbol);

			return await executor.ExecuteAsync<IEnumerable<SpinOffResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<SplitAdvancedResponse>>> SplitsAdvancedAsync(
			string symbol, TimeSeriesRange? range, bool calendar, int? last, string refId)
		{
			string urlPattern = "time-series/advanced_splits/[symbol]";
			urlPattern = GetBaseUrl(urlPattern, symbol);
			var qsb = GetQueryString(range, calendar, last, refId);
			var pathNvc = GetPathNvc(symbol);

			return await executor.ExecuteAsync<IEnumerable<SplitAdvancedResponse>>(urlPattern, pathNvc, qsb);
		}

		private QueryStringBuilder GetQueryString(TimeSeriesRange? range, bool calendar, int? last, string refId)
		{
			var queryStringBuilder = new QueryStringBuilder();

			if (range != null)
			{
				queryStringBuilder.Add("range", range.GetDescriptionFromEnum());
			}

			if (calendar)
			{
				queryStringBuilder.Add("calendar", "true");
			}

			if (last != null && last != 0)
			{
				queryStringBuilder.Add("last", last.ToString());
			}

			if (!string.IsNullOrEmpty(refId))
			{
				queryStringBuilder.Add("refId", refId);
			}

			return queryStringBuilder;
		}

		private NameValueCollection GetPathNvc(string symbol)
		{
			var pathNvc = new NameValueCollection();
			if (!string.IsNullOrEmpty(symbol))
			{
				pathNvc.Add("symbol", symbol);
			}

			return pathNvc;
		}

		private string GetBaseUrl(string baseUrl, string symbol)
		{
			if (string.IsNullOrEmpty(symbol))
			{
				baseUrl = baseUrl.Replace("[symbol]", "");
			}

			return baseUrl;
		}
	}
}
