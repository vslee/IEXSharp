using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.PremiumData.ExtractAlpha.Response;

namespace IEXSharp.Service.Cloud.PremiumData.ExtractAlpha
{
	public class ExtractAlphaService : IExtractAlphaService
	{
		private readonly ExecutorREST executor;

		internal ExtractAlphaService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<IEnumerable<CrossAssetModelOneResponse>>> CrossAssetModelOneAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<CrossAssetModelOneResponse>>($"time-series/PREMIUM_EXTRACT_ALPHA_CAM/{symbol}");

		public async Task<IEXResponse<IEnumerable<EsgCpscComplaintsResponse>>> EsgCpscComplaintsAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EsgCpscComplaintsResponse>>($"time-series/PREMIUM_EXTRACT_ALPHA_ESG/{symbol}/1");

		public async Task<IEXResponse<IEnumerable<EsgCpscRecallsResponse>>> EsgCpscRecallsAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EsgCpscRecallsResponse>>($"time-series/PREMIUM_EXTRACT_ALPHA_ESG/{symbol}/5");

		public async Task<IEXResponse<IEnumerable<EsgDolVisaApplicationsResponse>>> EsgDolVisaApplicationsAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EsgDolVisaApplicationsResponse>>($"time-series/PREMIUM_EXTRACT_ALPHA_ESG/{symbol}/8");

		public async Task<IEXResponse<IEnumerable<EsgEpaEnforcementsResponse>>> EsgEpaEnforcementsAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EsgEpaEnforcementsResponse>>($"time-series/PREMIUM_EXTRACT_ALPHA_ESG/{symbol}/2");

		public Task<IEXResponse<IEnumerable<object>>> EsgEpaMilestonesAsync(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<object>>> EsgFecIndividualCampaignContributionsAsync(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<object>>> EsgOshaInspectionsAsync(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<object>>> EsgSenateLobbyingAsync(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<object>>> EsgUsaSpendingAsync(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<object>>> EsgUsptoPatentApplicationsAsync(string symbol)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEXResponse<IEnumerable<object>>> TacticalModelOneAsync(string symbol)
		{
			throw new System.NotImplementedException();
		}
	}
}