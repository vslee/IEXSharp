using System;

namespace IEXSharp.Model.PremiumData.WallStreetHorizon.Response
{
	public class CompanyTravelResponse
	{
		public string eventId { get; set; }
		public string symbol { get; set; }
		public string companyName { get; set; }
		public DateTime announceDate { get; set; }
		public string organizer { get; set; }
		public string eventDesc { get; set; }
		public string eventStatus { get; set; }
		public string sectorNames { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public string localTimeStart { get; set; }
		public string timeZone { get; set; }
		public string venue { get; set; }
		public string venueAddress { get; set; }
		public string venueCity { get; set; }
		public string venueState { get; set; }
		public string venueCountry { get; set; }
		public string venueCountryIso { get; set; }
		public string purl { get; set; }
		public string inviteUrl { get; set; }
		public string scheduleUrl { get; set; }
		public string additionalInfoUrl { get; set; }
		public string externalNote { get; set; }
		public string referenceLink { get; set; }
		public long updated { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
	}
}