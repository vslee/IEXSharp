using System;

namespace IEXSharp.Model.CoreData.ForexCurrencies.Response
{
	public class CurrencyHistoricalRateResponse : CurrencyRateResponse
	{
		public DateTime? date { get; set; }
	}
}