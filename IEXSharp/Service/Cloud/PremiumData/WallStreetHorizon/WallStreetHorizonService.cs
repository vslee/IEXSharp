using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.PremiumData.WallStreetHorizon.Response;

namespace IEXSharp.Service.Cloud.PremiumData.WallStreetHorizon
{
	public class WallStreetHorizonService : IWallStreetHorizonService
	{
		private readonly ExecutorREST executor;

		internal WallStreetHorizonService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonResponse>>> AnalystDaysAsync(string symbol, string eventId)
		{
			const string url = "time-series/PREMIUM_WALLSTREETHORIZON_ANALYST_DAY/";
			var fullUrl = GetWallSymbolEventUrl(url, symbol, eventId);

			return await executor.NoParamExecute<IEnumerable<WallStreetHorizonResponse>>(fullUrl);
		}

		public async Task<IEXResponse<IEnumerable<BoardOfDirectorsMeetingResponse>>> BoardOfDirectorsMeetingAsync(string symbol, string eventId)
		{
			const string url = "time-series/PREMIUM_WALLSTREETHORIZON_BOARD_OF_DIRECTORS_MEETING/";
			var fullUrl = GetWallSymbolEventUrl(url, symbol, eventId);

			return await executor.NoParamExecute<IEnumerable<BoardOfDirectorsMeetingResponse>>(fullUrl);
		}

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonResponse>>> BusinessUpdatesAsync(string symbol, string eventId)
		{
			const string url = "time-series/PREMIUM_WALLSTREETHORIZON_BUSINESS_UPDATE/";
			var fullUrl = GetWallSymbolEventUrl(url, symbol, eventId);

			return await executor.NoParamExecute<IEnumerable<WallStreetHorizonResponse>>(fullUrl);
		}

		public async Task<IEXResponse<IEnumerable<BuybacksResponse>>> BuybacksAsync(string symbol, string eventId)
		{
			const string url = "time-series/PREMIUM_WALLSTREETHORIZON_BUYBACK/";
			var fullUrl = GetWallSymbolEventUrl(url, symbol, eventId);

			return await executor.NoParamExecute<IEnumerable<BuybacksResponse>>(fullUrl);
		}

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonResponse>>> CapitalMarketsDayAsync() =>
			await executor.NoParamExecute<IEnumerable<WallStreetHorizonResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_CAPITAL_MARKETS_DAY");

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonResponse>>> CompanyTravelAsync(string symbol, string eventId)
		{
			const string url = "time-series/PREMIUM_WALLSTREETHORIZON_COMPANY_TRAVEL/";
			var fullUrl = GetWallSymbolEventUrl(url, symbol, eventId);

			return await executor.NoParamExecute<IEnumerable<WallStreetHorizonResponse>>(fullUrl);
		}

		public async Task<IEXResponse<IEnumerable<FilingsDueDatesResponse>>> FilingDueDatesAsync() =>
			await executor.NoParamExecute<IEnumerable<FilingsDueDatesResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_FILING_DUE_DATE");

		public async Task<IEXResponse<IEnumerable<FiscalQuarterEndResponse>>> FiscalQuarterEndAsync() =>
			await executor.NoParamExecute<IEnumerable<FiscalQuarterEndResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_FISCAL_QUARTER_END_DATE");

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonEventResponse>>> ForumAsync() =>
			await executor.NoParamExecute<IEnumerable<WallStreetHorizonEventResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_FORUM");

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonEventResponse>>> GeneralConferenceAsync() =>
			await executor.NoParamExecute<IEnumerable<WallStreetHorizonEventResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_GENERAL_CONFERENCE");

		public async Task<IEXResponse<IEnumerable<FdaAdvisoryCommiteeMeetingsResponse>>> FdaAdvisoryCommitteeMeetingsAsync() =>
			await executor.NoParamExecute<IEnumerable<FdaAdvisoryCommiteeMeetingsResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_STOCK_SPECIFIC_FDA_ADVISORY_COMMITTEE_MEETING");

		public async Task<IEXResponse<IEnumerable<HolidaysResponse>>> HolidaysAsync() =>
			await executor.NoParamExecute<IEnumerable<HolidaysResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_HOLIDAYS");

		public async Task<IEXResponse<IEnumerable<IndexChangesResponse>>> IndexChangesAsync() =>
			await executor.NoParamExecute<IEnumerable<IndexChangesResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_INDEX_CHANGE");

		public async Task<IEXResponse<IEnumerable<IposResponse>>> IposAsync() =>
			await executor.NoParamExecute<IEnumerable<IposResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_INITIAL_PUBLIC_OFFERING");

		public async Task<IEXResponse<IEnumerable<LegalActionsResponse>>> LegalActionsAsync() =>
			await executor.NoParamExecute<IEnumerable<LegalActionsResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_LEGAL_ACTIONS");

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonResponse>>> MergersAndAcquisitionsAsync(string symbol, string eventId)
		{
			const string url = "time-series/PREMIUM_WALLSTREETHORIZON_MERGER_ACQUISITIONS/";
			var fullUrl = GetWallSymbolEventUrl(url, symbol, eventId);

			return await executor.NoParamExecute<IEnumerable<WallStreetHorizonResponse>>(fullUrl);
		}

		public async Task<IEXResponse<IEnumerable<ProductEventsResponse>>> ProductEventsAsync(string symbol, string eventId)
		{
			const string url = "time-series/PREMIUM_WALLSTREETHORIZON_PRODUCT_EVENTS/";
			var fullUrl = GetWallSymbolEventUrl(url, symbol, eventId);

			return await executor.NoParamExecute<IEnumerable<ProductEventsResponse>>(fullUrl);
		}

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonResponse>>> ResearchAndDevelopmentDaysAsync() =>
			await executor.NoParamExecute<IEnumerable<WallStreetHorizonResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_RD_DAY");

		public async Task<IEXResponse<IEnumerable<SameStoreSalesResponse>>> SameStoreSalesAsync(string symbol, string eventId)
		{
			const string url = "time-series/PREMIUM_WALLSTREETHORIZON_SAME_STORE_SALES/";
			var fullUrl = GetWallSymbolEventUrl(url, symbol, eventId);

			return await executor.NoParamExecute<IEnumerable<SameStoreSalesResponse>>(fullUrl);
		}

		public async Task<IEXResponse<IEnumerable<SecondaryOfferingsResponse>>> SecondaryOfferingsAsync() =>
			await executor.NoParamExecute<IEnumerable<SecondaryOfferingsResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_SECONDARY_OFFERING");

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonEventResponse>>> SeminarsAsync() =>
			await executor.NoParamExecute<IEnumerable<WallStreetHorizonEventResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_SEMINAR");

		public async Task<IEXResponse<IEnumerable<ShareHolderMeetingsResponse>>> ShareholderMeetingsAsync() =>
			await executor.NoParamExecute<IEnumerable<ShareHolderMeetingsResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_SHAREHOLDER_MEETING");

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonEventResponse>>> SummitMeetingsAsync() =>
			await executor.NoParamExecute<IEnumerable<WallStreetHorizonEventResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_SUMMIT_MEETING");

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonEventResponse>>> TradeShowsAsync() =>
			await executor.NoParamExecute<IEnumerable<WallStreetHorizonEventResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_TRADE_SHOW");

		public async Task<IEXResponse<IEnumerable<WitchingHourResponse>>> WitchingHoursAsync() =>
			await executor.NoParamExecute<IEnumerable<WitchingHourResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_WITCHING_HOURS");

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonEventResponse>>> WorkshopsAsync() =>
			await executor.NoParamExecute<IEnumerable<WallStreetHorizonEventResponse>>("time-series/PREMIUM_WALLSTREETHORIZON_WORKSHOP");

		private string GetWallSymbolEventUrl(string url, string symbol, string eventId)
		{
			if (string.IsNullOrEmpty(symbol))
			{
				url += symbol + "/";
			}

			if (string.IsNullOrEmpty(eventId))
			{
				url += eventId;
			}

			return url;
		}
	}
}