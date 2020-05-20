namespace IEXSharp.Model.PremiumData.ExtractAlpha.Response
{
	public class CrossAssetModelOneResponse
	{
		public long SpreadComponent { get; set; }
		public long SkewComponent { get; set; }
		public long VolumeComponent { get; set; }
		public long Cam1 { get; set; }
		public long Cam1Slow { get; set; }
		public string Updated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public string Date { get; set; }
	}
}