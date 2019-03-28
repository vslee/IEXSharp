namespace ZH.Code.IEX.V2.Model.ForexCurrencies.Response
{
    public class ExchangeRateResponse
    {
        public string date { get; set; }
        public string fromCurrency { get; set; }
        public string toCurrency { get; set; }
        public decimal rate { get; set; }
    }
}