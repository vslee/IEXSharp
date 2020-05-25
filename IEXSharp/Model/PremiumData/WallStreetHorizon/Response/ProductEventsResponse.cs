using System;

namespace IEXSharp.Model.PremiumData.WallStreetHorizon.Response
{
	public class ProductEventsResponse
	{
		public string eventid { get; set; }
		public string symbol { get; set; }
		public string companyname { get; set; }
		public DateTime releasedate { get; set; }
		public string releasetitle { get; set; }
		public string region { get; set; }
		public string distributor { get; set; }
		public string accuracy { get; set; }
		public long updated { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
	}
}