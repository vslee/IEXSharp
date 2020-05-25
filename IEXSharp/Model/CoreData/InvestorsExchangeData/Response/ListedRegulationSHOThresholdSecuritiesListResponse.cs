using Newtonsoft.Json;
using System;

namespace IEXSharp.Model.CoreData.InvestorsExchangeData.Response
{
	public class ListedRegulationSHOThresholdSecuritiesListResponse
	{
		public DateTime TradeDate { get; set; }

		[JsonProperty("SymbolinINET Symbology")]
		public string SymbolinINETSymbology { get; set; }

		[JsonProperty("SymbolinCQS Symbology")]
		public string SymbolinCQSSymbology { get; set; }

		[JsonProperty("SymbolinCMS Symbology")]
		public string SymbolinCMSSymbology { get; set; }

		public string SecurityName { get; set; }
	}
}