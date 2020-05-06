using IEXSharp.Helper;
using System.Diagnostics;

namespace IEXSharp.Model.StockPrices.Response
{
	[DebuggerDisplay("date={date}, open={open}, close={close}, high={high}, low={low}, vol={volume}")]
	public class HistoricalPriceResponse : ITimestamped
	{
		public string date { get; set; }
		public string minute { get; set; }
		public decimal open { get; set; }
		public decimal close { get; set; }
		public decimal high { get; set; }
		public decimal low { get; set; }
		public long volume { get; set; }
		public decimal uOpen { get; set; }
		public decimal uClose { get; set; }
		public decimal uHigh { get; set; }
		public decimal uLow { get; set; }
		public long uVolume { get; set; }
		public decimal change { get; set; }
		public long changePercent { get; set; }
		public long changeOverTime { get; set; }
		public string symbol { get; set; }
	}
}