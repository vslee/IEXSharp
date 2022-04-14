using System;

namespace IEXSharp.Model.PremiumData.WallStreetHorizon.Response
{
	public class IndexChangesResponse
	{
		public string eventid { get; set; }
		public string symbol { get; set; }
		public string companyname { get; set; }
		public string changetype { get; set; }
		public string indexname { get; set; }
		public DateTime announcedate { get; set; }
		public string announceurl { get; set; }
		public DateTime effectivedate { get; set; }
		public long replacecompanyid { get; set; }
		public string replaceticker { get; set; }
		public string replaceisin { get; set; }
		public string replacetickername { get; set; }
		public decimal updated { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
	}
}