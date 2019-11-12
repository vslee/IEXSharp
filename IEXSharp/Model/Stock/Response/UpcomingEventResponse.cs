using System.Collections.Generic;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Model.Stock.Response
{
    public class UpcomingEventSymbolResponse
    {
        public List<Estimate> earnings { get; set; }
        public List<Dividend> dividends { get; set; }
        public List<Split> splits { get; set; }
    }

    public class UpcomingEventMarketResponse
    {
        public IPOCalendar ips { get; set; }
        public List<Estimate> earnings { get; set; }
        public List<Dividend> dividends { get; set; }
        public List<Split> splits { get; set; }
    }
}