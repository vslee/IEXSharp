using IEXSharp.Helper;

namespace IEXSharp.Model.Stock.Response
{
	public class ChartLegacyResponse : ITimestampedDateMinute
	{
		/// <summary>
		/// Use DateTimeExtensions.GetTimestampInUTC(), which takes into account both 'date' and 'minute' and timezone
		/// </summary>
		public string date { get; set; }
		public string minute { get; set; }
		public string label { get; set; }
		public decimal high { get; set; }
		public decimal low { get; set; }
		public decimal average { get; set; }
		public int volume { get; set; }
		public decimal notional { get; set; }
		public int numberOfTrades { get; set; }
		public decimal marketHigh { get; set; }
		public decimal marketLow { get; set; }
		public decimal marketAverage { get; set; }
		public int marketVolume { get; set; }
		public decimal marketNotional { get; set; }
		public int marketNumberOfTrades { get; set; }
		public decimal? open { get; set; }
		public decimal? close { get; set; }
		public decimal marketOpen { get; set; }
		public decimal marketClose { get; set; }
		public decimal? changeOverTime { get; set; }
		public decimal marketChangeOverTime { get; set; }
	}
}