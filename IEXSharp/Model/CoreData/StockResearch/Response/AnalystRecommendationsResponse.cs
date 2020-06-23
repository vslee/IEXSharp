namespace IEXSharp.Model.CoreData.StockResearch.Response
{
	public class AnalystRecommendationsResponse
	{
		public long? consensusEndDate { get; set; }
		public long consensusStartDate { get; set; }
		public long? corporateActionsAppliedDate { get; set; }
		public int ratingBuy { get; set; }
		public int ratingOverweight { get; set; }
		public int ratingHold { get; set; }
		public int ratingUnderweight { get; set; }
		public int ratingSell { get; set; }
		public int ratingNone { get; set; }
		public decimal ratingScaleMark { get; set; }
	}
}
