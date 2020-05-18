namespace IEXSharp.Model.CoreData.ForexCurrencies.Response
{
	public class ExchangeRateResponse
	{
		public string date { get; set; }
		public string fromCurrency { get; set; }
		public string toCurrency { get; set; }
		public decimal rate { get; set; }
	}
}