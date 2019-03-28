using Newtonsoft.Json;

namespace IEX.V2.Model.InvestorsExchangeData.Response
{
    public class ListedRegulationSHOThresholdSecuritiesListResponse
    {
        public string TradeDate { get; set; }

        [JsonProperty("SymbolinINET Symbology")]
        public string SymbolinINETSymbology { get; set; }

        [JsonProperty("SymbolinCQS Symbology")]
        public string SymbolinCQSSymbology { get; set; }

        [JsonProperty("SymbolinCMS Symbology")]
        public string SymbolinCMSSymbology { get; set; }

        public string SecurityName { get; set; }
    }
}