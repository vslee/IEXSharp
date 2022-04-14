using System;

namespace IEXSharp.Model.Shared.Response
{
	public class Earning
	{
		public DateTime EPSReportDate { get; set; }
		public decimal EPSSurpriseDollar { get; set; }
		public decimal EPSSurpriseDollarPercent { get; set; }
		public decimal actualEPS { get; set; }
		public string announceTime { get; set; }
		public decimal consensusEPS { get; set; }
		public string currency { get; set; }
		public DateTime fiscalEndDate { get; set; }
		public string fiscalPeriod { get; set; }
		public int numberOfEstimates { get; set; }
		public string periodType { get; set; }
		public string symbol { get; set; }
		public decimal yearAgo { get; set; }
		public decimal yearAgoChangePercent { get; set; }
		public string id { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
		public decimal updated { get; set; }
	}
}