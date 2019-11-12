using System.Collections.Generic;
using IEXClient.Model.Shared.Response;

namespace IEXClient.Model.Stock.Response
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