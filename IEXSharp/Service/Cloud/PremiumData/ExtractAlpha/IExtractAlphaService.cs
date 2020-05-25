using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.PremiumData.ExtractAlpha.Response;

namespace IEXSharp.Service.Cloud.PremiumData.ExtractAlpha
{
	public interface IExtractAlphaService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#cross-asset-model-1" />
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CrossAssetModelOneResponse>>> CrossAssetModelOneAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#esg-cfpb-complaints" />
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EsgCpfbComplaintsResponse>>> EsgCpfbComplaintsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#esg-cpsc-recalls" />
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EsgCpscRecallsResponse>>> EsgCpscRecallsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#esg-dol-visa-applications" />
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EsgDolVisaApplicationsResponse>>> EsgDolVisaApplicationsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#esg-epa-enforcements" />
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EsgEpaEnforcementsResponse>>> EsgEpaEnforcementsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#esg-epa-milestones" />
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EsgEpaMilestonesResponse>>> EsgEpaMilestonesAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#esg-fec-individual-campaign-contributions" />
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EsgFecIndividualCampaignContributionsResponse>>> EsgFecIndividualCampaignContributionsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#esg-osha-inspections" />
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EsgOshaInspectionsResponse>>> EsgOshaInspectionsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#esg-senate-lobbying" />
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EsgSenateLobbyingResponse>>> EsgSenateLobbyingAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#esg-usa-spending" />
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EsgUsaSpendingResponse>>> EsgUsaSpendingAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#esg-uspto-patent-applications" />
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EsgUsptoPatentApplicationsResponse>>> EsgUsptoPatentApplicationsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#esg-uspto-patent-grants" />
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<EsgUsptoPatentGrantsResponse>>> EsgUsptoPatentGrantsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#tactical-model-1" />
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<TacticalModelOneResponse>>> TacticalModelOneAsync(string symbol);
	}
}