using System;

namespace IEXSharp.Model.Stock.Response
{
	public class Estimate
	{
		public decimal consensusEPS { get; set; }
		public string announceTime { get; set; }
		public long numberOfEstimates { get; set; }
		public DateTime reportDate { get; set; }
		public string fiscalPeriod { get; set; }
		public DateTime fiscalEndDate { get; set; }
	}
}