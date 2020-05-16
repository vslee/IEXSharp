namespace IEXSharp.Model.CoreData.InvestorsExchangeData.Response
{
	public class StatsHisoricalDailyResponse
	{
		public string date { get; set; }
		public long volume { get; set; }
		public long routedVolume { get; set; }
		public decimal marketShare { get; set; }
		public long isHalfday { get; set; }
		public long litVolume { get; set; }
	}
}