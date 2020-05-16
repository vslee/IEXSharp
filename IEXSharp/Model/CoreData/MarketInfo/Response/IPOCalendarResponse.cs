using System;
using System.Collections.Generic;

namespace IEXSharp.Model.CoreData.MarketInfo.Response
{
	public class IPOCalendarResponse
	{
		public List<RawData> rawData { get; set; }
		public List<ViewData> viewData { get; set; }
		public DateTime lastUpdate { get; set; }
	}

	public class RawData
	{
		public string symbol { get; set; }
		public string companyName { get; set; }
		public string expectedDate { get; set; }
		public List<string> leadUnderwriters { get; set; }
		public List<string> underwriters { get; set; }
		public List<string> companyCounsel { get; set; }
		public List<string> underwriterCounsel { get; set; }
		public string auditor { get; set; }
		public string market { get; set; }
		public string cik { get; set; }
		public string address { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string zip { get; set; }
		public string phone { get; set; }
		public string ceo { get; set; }
		public long employees { get; set; }
		public string url { get; set; }
		public string status { get; set; }
		public long sharesOffered { get; set; }
		public decimal priceLow { get; set; }
		public decimal priceHigh { get; set; }
		public long offerAmount { get; set; }
		public long totalExpenses { get; set; }
		public long sharesOverAlloted { get; set; }
		public long shareholderShares { get; set; }
		public long sharesOutstanding { get; set; }
		public string lockupPeriodExpiration { get; set; }
		public string quietPeriodExpiration { get; set; }
		public long revenue { get; set; }
		public long netIncome { get; set; }
		public long totalAssets { get; set; }
		public long totalLiabilities { get; set; }
		public long stockholderEquity { get; set; }
		public string companyDescription { get; set; }
		public string businessDescription { get; set; }
		public string useOfProceeds { get; set; }
		public string competition { get; set; }
		public long amount { get; set; }
		public string percentOffered { get; set; }
	}

	public class ViewData
	{
		public class Quote
		{
			public float latestPrice { get; set; }
			public float changePercent { get; set; }
		}

		public string Company { get; set; }
		public string Symbol { get; set; }
		public string Price { get; set; }
		public string Shares { get; set; }
		public string Amount { get; set; }
		public string Float { get; set; }
		public string Percent { get; set; }
		public string Market { get; set; }
		public string Expected { get; set; }
		public ViewData.Quote quote { get; set; }
	}
}