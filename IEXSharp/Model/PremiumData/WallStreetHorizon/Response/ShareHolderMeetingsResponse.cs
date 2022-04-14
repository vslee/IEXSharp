using System;

namespace IEXSharp.Model.PremiumData.WallStreetHorizon.Response
{
	public class ShareHolderMeetingsResponse
	{
		public string eventid { get; set; }
		public string symbol { get; set; }
		public string companyname { get; set; }
		public DateTime announcedate { get; set; }
		public DateTime startdate { get; set; }
		public DateTime enddate { get; set; }
		public string localtimestart { get; set; }
		public string timezone { get; set; }
		public DateTime recorddate { get; set; }
		public string venue { get; set; }
		public string venueaddress { get; set; }
		public string venuecity { get; set; }
		public string venuestate { get; set; }
		public string venuecountry { get; set; }
		public string venuecountryiso { get; set; }
		public string purl { get; set; }
		public string shmdistance { get; set; }
		public string referencelink { get; set; }
		public object shmmeetingtype { get; set; }
		public decimal updated { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
	}
}