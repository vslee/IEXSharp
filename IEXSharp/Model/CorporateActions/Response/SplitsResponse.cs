namespace IEXSharp.Model.CorporateActions.Response
{
	public class SplitsResponse : CorporateActionResponse
	{
		public string splitType { get; set; }
		public double oldParValue { get; set; }
		public string oldParValueCurrency { get; set; }
	}
}