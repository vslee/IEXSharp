using System;

namespace IEXSharp.Model.PremiumData.WallStreetHorizon.Response
{
	public class SecondaryOfferingsResponse
	{
		public string eventid { get; set; }
		public string symbol { get; set; }
		public string companyname { get; set; }
		public string offeringstage { get; set; }
		public string sellingshareholder { get; set; }
		public long numberofshares { get; set; }
		public double shareprice { get; set; }
		public string currency { get; set; }
		public object sharesdifferent { get; set; }
		public DateTime announcedate { get; set; }
		public DateTime? effectivedate { get; set; }
		public DateTime? closingdate { get; set; }
		public string offeringproceeds { get; set; }
		public string underwritermanager { get; set; }
		public string prospectuslink { get; set; }
		public string linktopublication { get; set; }
		public decimal updated { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
	}
}