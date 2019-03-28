using IEX.V2.Model.Shared.Response;
using System.Collections.Generic;

namespace IEX.V2.Model.Stock.Response
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