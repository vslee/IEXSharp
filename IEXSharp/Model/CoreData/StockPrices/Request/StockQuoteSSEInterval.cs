using System.ComponentModel;

namespace IEXSharp.Model.CoreData.StockPrices.Request
{
	public enum StockQuoteSSEInterval
	{
		/// <summary>
		/// Firehose can be about 100 million messages per day
		/// </summary>
		[Description("")] // no suffix needed for firehose
		Firehose,
		/// <summary>
		/// Can be up to 54,000 messages per symbol per day
		/// </summary>
		[Description("1Second")]
		OneSecond,
		/// <summary>
		/// Can be up to 10,800 messages per symbol per day
		/// </summary>
		[Description("5Second")]
		FiveSeconds,
		/// <summary>
		/// Can be up to 900 messages per symbol per day
		/// </summary>
		[Description("1Minute")]
		OneMinute,
	}
}
