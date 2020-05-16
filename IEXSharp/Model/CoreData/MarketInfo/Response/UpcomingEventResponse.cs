using System.Collections.Generic;
using IEXSharp.Model.CoreData.Stock.Response;
using IEXSharp.Model.CoreData.StockFundamentals.Response;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Model.CoreData.MarketInfo.Response
{
	public class UpcomingEventSymbolResponse
	{
		public List<Estimate> earnings { get; set; }
		public List<Dividend> dividends { get; set; }
		public List<Split> splits { get; set; }
	}

	public class UpcomingEventMarketResponse
	{
		public IPOCalendarResponse ipos { get; set; }
		public List<UpcomingEarningEvent> earnings { get; set; }
		public List<Dividend> dividends { get; set; }
		public List<Split> splits { get; set; }
	}
}