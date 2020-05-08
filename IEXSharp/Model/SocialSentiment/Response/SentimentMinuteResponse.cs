using IEXSharp.Helper;

namespace IEXSharp.Model.SocialSentiment.Response
{
	public class SentimentMinuteResponse : SentimentResponse, ITimestampedMinute
	{
		public string minute { get; set; }
	}
}
