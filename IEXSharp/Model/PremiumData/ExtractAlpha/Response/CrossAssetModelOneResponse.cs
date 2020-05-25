namespace IEXSharp.Model.PremiumData.ExtractAlpha.Response
{
	public class CrossAssetModelOneResponse
	{
		public decimal SpreadComponent { get; set; }
		public decimal SkewComponent { get; set; }
		public decimal VolumeComponent { get; set; }
		public decimal Cam1 { get; set; }
		public decimal Cam1Slow { get; set; }
		public long Updated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public long Date { get; set; }
	}
}