namespace IEXSharp.Model.CoreData.InvestorsExchangeData.Response
{
	public class DeepTradeStreamResponse
	{
		public string Symbol { get; set; }
		public string MessageType { get; set; }
		public DeepTradeResponse Data { get; set; }
	}
}