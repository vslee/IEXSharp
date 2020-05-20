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

		public async Task<IEXResponse<IEnumerable<EsgEpaMilestonesResponse>>> EsgEpaMilestonesAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EsgEpaMilestonesResponse>>($"time-series/PREMIUM_EXTRACT_ALPHA_ESG/{symbol}/3");

		public async Task<IEXResponse<IEnumerable<EsgFecIndividualCampaignContributionsResponse>>> EsgFecIndividualCampaignContributionsAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EsgFecIndividualCampaignContributionsResponse>>($"time-series/PREMIUM_EXTRACT_ALPHA_ESG/{symbol}/7");

		public async Task<IEXResponse<IEnumerable<EsgOshaInspectionsResponse>>> EsgOshaInspectionsAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EsgOshaInspectionsResponse>>($"time-series/PREMIUM_EXTRACT_ALPHA_ESG/{symbol}/4");

		public async Task<IEXResponse<IEnumerable<EsgSenateLobbyingResponse>>> EsgSenateLobbyingAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EsgSenateLobbyingResponse>>($"time-series/PREMIUM_EXTRACT_ALPHA_ESG/{symbol}/6");

		public async Task<IEXResponse<IEnumerable<EsgUsaSpendingResponse>>> EsgUsaSpendingAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EsgUsaSpendingResponse>>($"time-series/PREMIUM_EXTRACT_ALPHA_ESG/{symbol}/9");

		public async Task<IEXResponse<IEnumerable<EsgUsptoPatentApplicationsResponse>>> EsgUsptoPatentApplicationsAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EsgUsptoPatentApplicationsResponse>>($"time-series/PREMIUM_EXTRACT_ALPHA_ESG/{symbol}/10");

		public async Task<IEXResponse<IEnumerable<EsgUsptoPatentGrantsResponse>>> EsgUsptoPatentGrantsAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<EsgUsptoPatentGrantsResponse>>($"time-series/PREMIUM_EXTRACT_ALPHA_ESG/{symbol}/11");

		public async Task<IEXResponse<IEnumerable<TacticalModelOneResponse>>> TacticalModelOneAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<TacticalModelOneResponse>>($"time-series/PREMIUM_EXTRACT_ALPHA_TM/{symbol}");
	}
}