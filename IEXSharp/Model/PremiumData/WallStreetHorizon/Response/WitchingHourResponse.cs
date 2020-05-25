using System;

namespace IEXSharp.Model.PremiumData.WallStreetHorizon.Response
{
	public class WitchingHourResponse
	{
		public string eventid { get; set; }
		public DateTime eventdate { get; set; }
		public string eventday { get; set; }
		public string eventname { get; set; }
		public string financialcentername { get; set; }
		public long updated { get; set; }
		public string symbol { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
	}
}