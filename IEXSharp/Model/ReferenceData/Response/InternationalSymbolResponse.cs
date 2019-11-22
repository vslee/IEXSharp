namespace VSLee.IEXSharp.Model.ReferenceData.Response
{
	public class InternationalSymbolResponse
	{
		public string symbol { get; set; }
		public string exchange { get; set; }
		public string name { get; set; }
		public string date { get; set; }
		public string type { get; set; }
		public string iexId { get; set; }
		public string region { get; set; }
		public string currency { get; set; }
		public bool isEnabled { get; set; }
	}
}