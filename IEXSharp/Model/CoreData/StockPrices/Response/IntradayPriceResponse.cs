using IEXSharp.Helper;

namespace IEXSharp.Model.CoreData.StockPrices.Response
{
	public class IntradayPriceResponse : ITimestampedDateMinute
	{
		/// <summary> Use DateTimeExtensions.GetTimestampInUTC(), which takes into account both 'date' and 'minute' and timezone </summary>
		public string date { get; set; }
		/// <summary> Use DateTimeExtensions.GetTimestampInUTC(), which takes into account both 'date' and 'minute' and timezone </summary>
		public string minute { get; set; }
		public string label { get; set; } // can be null
		public decimal? marketOpen { get; set; }
		public decimal? marketClose { get; set; }
		public decimal? marketHigh { get; set; }
		public decimal? marketLow { get; set; }
		public decimal? marketAverage { get; set; }
		public long? marketVolume { get; set; }
		public decimal? marketNotional { get; set; }
		public long? marketNumberOfTrades { get; set; }
		public decimal? marketChangeOverTime { get; set; }
		public decimal? high { get; set; }
		public decimal? low { get; set; }
		public decimal? open { get; set; }
		public decimal? close { get; set; }
		public decimal? average { get; set; }
		public long? volume { get; set; }
		public decimal? notional { get; set; }
		public long? numberOfTrades { get; set; }
		public decimal? changeOverTime { get; set; }
	}
}