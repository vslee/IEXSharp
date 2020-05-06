namespace IEXSharp.Model.SocialSentiment.Response
{
	public class SentimentResponse
	{
		public decimal sentiment { get; set; }
		public int totalScores { get; set; }
		public decimal positive { get; set; }
		public decimal negative { get; set; }
	}
}
