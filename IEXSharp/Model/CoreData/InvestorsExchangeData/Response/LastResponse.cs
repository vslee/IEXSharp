namespace IEXSharp.Model.CoreData.InvestorsExchangeData.Response
{
	public class LastResponse
	{
		public string symbol { get; set; }
		public decimal price { get; set; }
		public int size { get; set; }
		public long time { get; set; }
	}
}