namespace VSLee.IEXSharp.Model.AlternativeData.Response
{
	public class SocialSentimentDailyResponse
	{
		public decimal sentiment { get; set; }
		public int totalScores { get; set; }
		public decimal positive { get; set; }
		public decimal negative { get; set; }
	}

	public class SocialSentimentMinuteResponse
	{
		public decimal sentiment { get; set; }
		public int totalScores { get; set; }
		public decimal positive { get; set; }
		public decimal negative { get; set; }
		public int minute { get; set; }
	}
}