using System;

namespace IEXSharp.Model.CoreData.ForexCurrencies.Response
{
	public class ExchangeRateResponse
	{
		// "{\"fromCurrency\":\"UER\",\"toCurrency\":\"DUS\",\"rate\":1.14,\"date\":\"2020-01-17\"}"
		public DateTime date { get; set; }
		public string fromCurrency { get; set; }
		public string toCurrency { get; set; }
		public decimal rate { get; set; }
	}
}