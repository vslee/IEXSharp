using System.Diagnostics;
using IEXSharp.Helper;

namespace IEXSharp.Model.CoreData.StockPrices.Response
{
	[DebuggerDisplay("date={date}, open={open}, close={close}, high={high}, low={low}, vol={volume}")]
	public class HistoricalPriceResponse : ITimestampedDateMinute
	{
		/// <summary>
		/// Use DateTimeExtensions.GetTimestampInUTC(), which takes into account both 'date' and 'minute' and timezone
		/// </summary>
		public string date { get; set; }
		public string minute { get; set; }
		public decimal? open { get; set; }
		public decimal? close { get; set; }
		public decimal? high { get; set; }
		public decimal? low { get; set; }
		public long volume { get; set; }
		public decimal? uOpen { get; set; }
		public decimal? uClose { get; set; }
		public decimal? uHigh { get; set; }
		public decimal? uLow { get; set; }
		public long? uVolume { get; set; }
		public decimal? change { get; set; }
		public decimal? changePercent { get; set; }
		public decimal? changeOverTime { get; set; }
		public string symbol { get; set; }
	}
}