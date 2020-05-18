using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.PremiumData.WallStreetHorizon.Response;

namespace IEXSharp.Service.Cloud.PremiumData.WallStreetHorizon
{
	public interface IWallStreetHorizonService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#analyst-days"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// /// <param name="eventId">Event ID</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<WallStreetHorizonResponse>>> AnalystDaysAsync(string symbol, string eventId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#board-of-directors-meeting"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// /// <param name="eventId">Event ID</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<BoardOfDirectorsMeetingResponse>>> BoardOfDirectorsMeetingAsync(string symbol, string eventId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#business-updates"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// /// <param name="eventId">Event ID</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<WallStreetHorizonResponse>>> BusinessUpdatesAsync(string symbol, string eventId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#buybacks"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// /// <param name="eventId">Event ID</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<BuybacksResponse>>> BuybacksAsync(string symbol, string eventId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#capital-markets-day"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<WallStreetHorizonResponse>>> CapitalMarketsDayAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#company-travel"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// /// <param name="eventId">Event ID</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<WallStreetHorizonResponse>>> CompanyTravelAsync(string symbol, string eventId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#filing-due-dates"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<FilingsDueDatesResponse>>> FilingDueDatesAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#fiscal-quarter-end"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<FiscalQuarterEndResponse>>> FiscalQuarterEndAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#forum"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<WallStreetHorizonEventResponse>>> ForumAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#general-conference"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<WallStreetHorizonEventResponse>>> GeneralConferenceAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#fda-advisory-committee-meetings"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<FdaAdvisoryCommiteeMeetingsResponse>>> FdaAdvisoryCommitteeMeetingsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#holidays"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<HolidaysResponse>>> HolidaysAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#index-changes"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<IndexChangesResponse>>> IndexChangesAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#ipos"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<IposResponse>>> IposAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#legal-actions"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<LegalActionsResponse>>> LegalActionsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#mergers-acquisitions"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <param name="eventId">Event ID</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<WallStreetHorizonResponse>>> MergersAndAcquisitionsAsync(string symbol, string eventId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#product-events"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <param name="eventId">Event ID</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<ProductEventsResponse>>> ProductEventsAsync(string symbol, string eventId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#research-and-development-days"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<WallStreetHorizonResponse>>> ResearchAndDevelopmentDaysAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#same-store-sales"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <param name="eventId">Event ID</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SameStoreSalesResponse>>> SameStoreSalesAsync(string symbol, string eventId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#secondary-offerings"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SecondaryOfferingsResponse>>> SecondaryOfferingsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#seminars"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<WallStreetHorizonEventResponse>>> SeminarsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#shareholder-meetings"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<ShareHolderMeetingsResponse>>> ShareholderMeetingsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#summit-meetings"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<WallStreetHorizonEventResponse>>> SummitMeetingsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#trade-shows"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<WallStreetHorizonEventResponse>>> TradeShowsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#witching-hours"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<WitchingHourResponse>>> WitchingHoursAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#workshops"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<WallStreetHorizonEventResponse>>> WorkshopsAsync();
	}
}
