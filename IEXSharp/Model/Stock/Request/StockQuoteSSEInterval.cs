namespace IEXSharp.Model.Stock.Request
{
	public enum StockQuoteSSEInterval
	{
		/// <summary>
		/// Firehose can be about 100 million messages per day
		/// </summary>
		Firehose,
		/// <summary>
		/// Can be up to 54,000 messages per symbol per day
		/// </summary>
		OneSecond,
		/// <summary>
		/// Can be up to 10,800 messages per symbol per day
		/// </summary>
		FiveSeconds,
		/// <summary>
		/// Can be up to 900 messages per symbol per day
		/// </summary>
		OneMinute,
	}
}
