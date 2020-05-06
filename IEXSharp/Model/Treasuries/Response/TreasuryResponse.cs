namespace IEXSharp.Model.Treasuries.Response
{
	public class TreasuryResponse
	{
		public decimal value { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		//public long date { get; set; }
		public long updated { get; set; }
	}
}
