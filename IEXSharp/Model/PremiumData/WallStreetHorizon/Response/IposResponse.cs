using System;

namespace IEXSharp.Model.PremiumData.WallStreetHorizon.Response
{
	public class IposResponse
	{
		public string eventid { get; set; }
		public string ipostatus { get; set; }
		public string symbol { get; set; }
		public string modified { get; set; }
		public long iposcoopid { get; set; }
		public string iposcoopcompanyname { get; set; }
		public string industry { get; set; }
		public DateTime fileddate { get; set; }
		public DateTime offeringdate { get; set; }
		public double offerprice { get; set; }
		public double firstdayclose { get; set; }
		public double currentprice { get; set; }
		public double @return { get; set; }
		public double shares { get; set; }
		public double pricerangelow { get; set; }
		public double pricerangehigh { get; set; }
		public double volume { get; set; }
		public string managers { get; set; }
		public string quietperiod { get; set; }
		public string lockupperiod { get; set; }
		public double rating { get; set; }
		public decimal updated { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
	}
}