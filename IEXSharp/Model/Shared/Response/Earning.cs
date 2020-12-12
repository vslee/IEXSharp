using System;

namespace IEXSharp.Model.Shared.Response
{
	public class Earning
	{
		public DateTime EPSReportDate { get; set; }
		public double EPSSurpriseDollar { get; set; }
		public double EPSSurpriseDollarPercent { get; set; }
		public double actualEPS { get; set; }
		public string announceTime { get; set; }
		public double consensusEPS { get; set; }
		public string currency { get; set; }
		public DateTime fiscalEndDate { get; set; }
		public string fiscalPeriod { get; set; }
		public int numberOfEstimates { get; set; }
		public string periodType { get; set; }
		public string symbol { get; set; }
		public double yearAgo { get; set; }
		public double yearAgoChangePercent { get; set; }
		public string id { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
		public long updated { get; set; }
	}
}