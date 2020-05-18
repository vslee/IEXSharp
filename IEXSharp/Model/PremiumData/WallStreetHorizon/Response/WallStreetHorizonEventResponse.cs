namespace IEXSharp.Model.PremiumData.WallStreetHorizon.Response
{
	public class WallStreetHorizonEventResponse
	{
		public string eventid { get; set; }
        public string announcedate { get; set; }
        public string organizer { get; set; }
        public string eventdesc { get; set; }
        public string eventstatus { get; set; }
        public string sectornames { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string localtimestart { get; set; }
        public string timezone { get; set; }
        public string venue { get; set; }
        public string venueaddress { get; set; }
        public string venuecity { get; set; }
        public string venuestate { get; set; }
        public string venuecountry { get; set; }
        public string venuecountryiso { get; set; }
        public string purl { get; set; }
        public string inviteurl { get; set; }
        public string scheduleurl { get; set; }
        public string additionalinfourl { get; set; }
        public string externalnote { get; set; }
        public string referencelink { get; set; }
        public string updated { get; set; }
        public presenters presenters { get; set; }
        public string symbol { get; set; }
        public string id { get; set; }
        public string source { get; set; }
        public string key { get; set; }
        public string subkey { get; set; }
        public string date { get; set; }
    }

	public class presenters
    {
        public presenter presenter { get; set; }
    }

    public class presenter
    {
        public string eventid { get; set; }
        public string symbol { get; set; }
        public string companyname { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string time { get; set; }
        public string announcedate { get; set; }
        public string presentername { get; set; }
        public string presentertitle { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
    }
}