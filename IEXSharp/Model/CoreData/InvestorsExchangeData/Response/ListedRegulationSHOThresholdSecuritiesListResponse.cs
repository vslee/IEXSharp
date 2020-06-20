using System;
using System.Text.Json.Serialization;

namespace IEXSharp.Model.CoreData.InvestorsExchangeData.Response
{
	public class ListedRegulationSHOThresholdSecuritiesListResponse
	{
		public DateTime TradeDate { get; set; }

		[JsonPropertyName("SymbolinINET Symbology")]
		public string SymbolinINETSymbology { get; set; }

		[JsonPropertyName("SymbolinCQS Symbology")]
		public string SymbolinCQSSymbology { get; set; }

		[JsonPropertyName("SymbolinCMS Symbology")]
		public string SymbolinCMSSymbology { get; set; }

		public string SecurityName { get; set; }
	}
}