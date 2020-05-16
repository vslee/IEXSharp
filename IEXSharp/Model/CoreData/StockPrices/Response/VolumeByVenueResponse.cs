using System;

namespace IEXSharp.Model.CoreData.StockPrices.Response
{
	public class VolumeByVenueResponse
	{
		public long volume { get; set; }
		public string venue { get; set; }
		public string venueName { get; set; }
		public decimal marketPercent { get; set; }
		public decimal avgMarketPercent { get; set; }
		public DateTime date { get; set; }
	}
}