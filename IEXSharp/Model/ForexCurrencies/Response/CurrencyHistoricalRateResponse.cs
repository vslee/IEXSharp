using System;

namespace IEXSharp.Model.ForexCurrencies.Response
{
	public class CurrencyHistoricalRateResponse : CurrencyRateResponse
	{
		public DateTime? date { get; set; }
	}
}