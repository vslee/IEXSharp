namespace IEXSharp.Model.InvestorsExchangeData.Response
{
	public class StatsIntradayResponse
	{
		public StatsIntradayValue volume { get; set; }
		public StatsIntradayValue symbolsTraded { get; set; }
		public StatsIntradayValue routedVolume { get; set; }
		public StatsIntradayValue notional { get; set; }
		public StatsIntradayValue marketShare { get; set; }
	}

	public class StatsIntradayValue
	{
		public decimal value { get; set; }
		public long lastUpdated { get; set; }
	}
}