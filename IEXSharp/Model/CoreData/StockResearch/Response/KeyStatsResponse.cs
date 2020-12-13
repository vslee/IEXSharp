using System;

namespace IEXSharp.Model.CoreData.StockResearch.Response
{
	public class KeyStatsResponse
	{
		public string companyName { get; set; }
		public long? marketcap { get; set; }
		public decimal? week52high { get; set; }
		public decimal? week52low { get; set; }
		public decimal? week52change { get; set; }
		public long? sharesOutstanding { get; set; }
		public string symbol { get; set; }
		public decimal? avg10Volume { get; set; }
		public decimal? avg30Volume { get; set; }
		public decimal? day200MovingAvg { get; set; }
		public decimal? day50MovingAvg { get; set; }
		public long? employees { get; set; }
		public decimal? ttmEPS { get; set; }
		public decimal? ttmDividendRate { get; set; }
		public decimal? dividendYield { get; set; }
		public DateTime? nextDividendDate { get; set; }
		public DateTime? exDividendDate { get; set; }
		public decimal? peRatio { get; set; }
		public decimal? beta { get; set; }
		public decimal? maxChangePercent { get; set; }
		public decimal? year5ChangePercent { get; set; }
		public decimal? year2ChangePercent { get; set; }
		public decimal? year1ChangePercent { get; set; }
		public decimal? ytdChangePercent { get; set; }
		public decimal? month6ChangePercent { get; set; }
		public decimal? month3ChangePercent { get; set; }
		public decimal? month1ChangePercent { get; set; }
		public decimal? day30ChangePercent { get; set; }
		public decimal? day5ChangePercent { get; set; }
	}
}