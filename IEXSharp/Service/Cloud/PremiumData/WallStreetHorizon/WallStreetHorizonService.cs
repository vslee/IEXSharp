using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;
using IEXSharp.Model.CoreData.CeoCompensation.Response;
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

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonService>>> AnalystDaysAsync(string symbol, string eventId)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<BoardOfDirectorsMeetingResponse>>> BoardOfDirectorsMeetingAsync(string symbol, string eventId)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonService>>> BusinessUpdatesAsync(string symbol, string eventId)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<BuybacksResponse>>> BuybacksAsync(string symbol, string eventId)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonService>>> CapitalMarketsDayAsync() =>
			await executor.NoParamExecute<IEnumerable<WallStreetHorizonService>>("/time-series/PREMIUM_WALLSTREETHORIZON_CAPITAL_MARKETS_DAY");

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonService>>> CompanyTravelAsync(string symbol, string eventId)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<FilingsDueDatesResponse>>> FilingDueDatesAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<FiscalQuarterEndResponse>>> FiscalQuarterEndAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonEventResponse>>> ForumAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonEventResponse>>> GeneralConferenceAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<FdaAdvisoryCommiteeMeetingsResponse>>> FdaAdvisoryCommitteeMeetingsAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<HolidaysResponse>>> HolidaysAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<IndexChangesResponse>>> IndexChangesAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<IposResponse>>> IposAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<LegalActionsResponse>>> LegalActionsAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonResponse>>> MergersAndAcquisitionsAsync(string symbol, string eventId)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<ProductEventsResponse>>> ProductEventsAsync(string symbol, string eventId)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<WallStreetHorizonResponse>>> ResearchAndDevelopmentDaysAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> SameStoreSalesAsync(string symbol, string eventId)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> SecondaryOfferingsAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> SeminarsAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> ShareholderMeetingsAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> SummitMeetingsAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> TradeShowsAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> WitchingHoursAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEXResponse<IEnumerable<CeoCompensationResponse>>> WorkshopsAsync()
		{
			throw new System.NotImplementedException();
		}
	}
}