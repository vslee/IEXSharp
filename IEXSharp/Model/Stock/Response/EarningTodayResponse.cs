using System.Collections.Generic;
using VSLee.IEXSharp.Model.Shared.Response;

namespace VSLee.IEXSharp.Model.Stock.Response
{
	public class EarningTodayResponse
	{
		public List<Earning> bto { get; set; }
		public List<Earning> amc { get; set; }
		public List<Other> other { get; set; }

		public class Earning
		{
			public decimal actualEPS { get; set; }
			public decimal consensusEPS { get; set; }
			public decimal estimatedEPS { get; set; }
			public string announceTime { get; set; }
			public long numberOfEstimates { get; set; }
			public decimal EPSSurpriseDollar { get; set; }
			public string EPSReportDate { get; set; }
			public string fiscalPeriod { get; set; }
			public string fiscalEndDate { get; set; }
			public decimal yearAgo { get; set; }
			public decimal yearAgoChangePercent { get; set; }
			public decimal estimatedChangePercent { get; set; }
			public int symbolId { get; set; }
			public string symbol { get; set; }
			public Quote quote { get; set; }
			public string headline { get; set; }
		}
		public class Other
		{
			public long? consensusEPS { get; set; }
			public string announceTime { get; set; }
			public long numberOfEstimates { get; set; }
			public string fiscalPeriod { get; set; }
			public string fiscalEndDate { get; set; }
			public string symbol { get; set; }
			public Quote quote { get; set; }
		}
	}
}