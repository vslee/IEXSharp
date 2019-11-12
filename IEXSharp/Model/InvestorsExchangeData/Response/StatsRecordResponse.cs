using System;

namespace IEXSharp.Model.InvestorsExchangeData.Response
{
	public class StatsRecordResponse
	{
		public StatsRecordsValue volume { get; set; }
		public StatsRecordsValue symbolsTraded { get; set; }
		public StatsRecordsValue routedVolume { get; set; }
		public StatsRecordsValue notional { get; set; }
	}

	public class StatsRecordsValue
	{
		public decimal recordValue { get; set; }
		public DateTime recordDate { get; set; }
		public decimal previousDayValue { get; set; }
		public decimal avg30Value { get; set; }
	}
}