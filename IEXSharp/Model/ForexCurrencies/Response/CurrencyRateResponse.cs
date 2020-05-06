namespace IEXSharp.Model.ForexCurrencies.Response
{
	public class CurrencyRateResponse
	{
		public string symbol { get; set; }
		public decimal rate { get; set; }
		public long timestamp { get; set; }
	}
}