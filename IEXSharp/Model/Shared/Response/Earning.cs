using System;

namespace IEXSharp.Model.Shared.Response
{
	public class Earning
	{
		public decimal actualEPS { get; set; }
		public decimal consensusEPS { get; set; }
		public string announceTime { get; set; }
		public int numberOfEstimates { get; set; }
		public decimal EPSSurpriseDollar { get; set; }
		public DateTime EPSReportDate { get; set; }
		public string fiscalPeriod { get; set; }
		public DateTime fiscalEndDate { get; set; }
		public decimal yearAgo { get; set; }
		public decimal yearAgoChangePercent { get; set; }
		public string currency { get; set; }
	}
}