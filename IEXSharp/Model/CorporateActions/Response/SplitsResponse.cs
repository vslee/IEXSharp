namespace IEXSharp.Model.CorporateActions.Response
{
	public class SplitAdvancedResponse : CorporateActionResponse
	{
		public string splitType { get; set; }
		public double oldParValue { get; set; }
		public string oldParValueCurrency { get; set; }
	}
}