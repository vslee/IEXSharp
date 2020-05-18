using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.CeoCompensation.Response;
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
		Task<IEXResponse<IEnumerable<WallStreetHorizonService>>> AnalystDaysAsync(string symbol, string eventId);

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
		Task<IEXResponse<IEnumerable<WallStreetHorizonService>>> BusinessUpdatesAsync(string symbol, string eventId);

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
		Task<IEXResponse<IEnumerable<WallStreetHorizonService>>> CapitalMarketsDayAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#company-travel"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// /// <param name="eventId">Event ID</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<WallStreetHorizonService>>> CompanyTravelAsync(string symbol, string eventId);

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
		Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> IndexChangesAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#ipos"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> IposAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#legal-actions"/>
		/// </summary>
		/// <returns></returns>
		// TODO - This feels like it should take a symbol / event ID
		Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> LegalActionsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#mergers-acquisitions"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <param name="eventId">Event ID</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> MergersAndAcquisitionsAsync(string symbol, string eventId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#product-events"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <param name="eventId">Event ID</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> ProductEventsAsync(string symbol, string eventId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#research-and-development-days"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> ResearchAndDevelopmentDaysAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#same-store-sales"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <param name="eventId">Event ID</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> SameStoreSalesAsync(string symbol, string eventId);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#secondary-offerings"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> SecondaryOfferingsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#seminars"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> SeminarsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#shareholder-meetings"/>
		/// </summary>
		/// <returns></returns>
		// TODO - This feels like it should take a symbol / event ID
		Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> ShareholderMeetingsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#summit-meetings"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> SummitMeetingsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#trade-shows"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> TradeShowsAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#witching-hours"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> WitchingHoursAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#workshops"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> WorkshopsAsync();
	}
}
