using System;

namespace IEXSharp.Model.PremiumData.BrainCompany.Response
{
	public class EstimatedReturnRankingResponse
	{
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public DateTime Subkey { get; set; }
		public DateTime CalculationDate { get; set; }
		public string CompanyName { get; set; }
		public string CompositeFigi { get; set; }
		public string Symbol { get; set; }
		public decimal MlAlpha { get; set; }
		public int DaysForecast { get; set; }
		public string Updated { get; set; }
	}
}