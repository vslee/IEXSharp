namespace IEXSharp.Model.CoreData.News.Response
{
	public class HistoricalNewResponse : NewsResponse
	{
		public string qmUrl { get; set; }
		public string imageUrl { get; set; }
		public string id { get; set; }
		public string key { get; set; }
		public string subkey  { get; set; }
		public long date { get; set; }
		public long updated { get; set; }
	}
}
