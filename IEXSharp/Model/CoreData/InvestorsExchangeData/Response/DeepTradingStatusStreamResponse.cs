namespace IEXSharp.Model.CoreData.InvestorsExchangeData.Response
{
	public class DeepTradingStatusStreamResponse
	{
		public string Symbol { get; set; }
		public DeepTradingStatusResponse Data { get; set; }
	}
}