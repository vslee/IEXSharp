using System;

namespace IEXSharp.Model.PremiumData.WallStreetHorizon.Response
{
	public class FiscalQuarterEndResponse
	{
		public string eventid { get; set; }
		public string symbol { get; set; }
		public string companyname { get; set; }
		public DateTime quarterenddate { get; set; }
		public string quarter { get; set; }
		public long fiscalyear { get; set; }
		public decimal updated { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
	}
}