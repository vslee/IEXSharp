using System;

namespace IEXSharp.Model.PremiumData.PrecisionAlpha.Response
{
	public class PriceDynamicsResponse
	{
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public DateTime Subkey { get; set; }
		public string Symbol { get; set; }
		public string CompanyName { get; set; }
		public DateTime CloseDate { get; set; }
		public decimal ProbabilityUp { get; set; }
		public decimal ProbabilityDown { get; set; }
		public decimal MarketEmotion { get; set; }
		public decimal MarketPower { get; set; }
		public decimal MarketResistance { get; set; }
		public decimal MarketNoise { get; set; }
		public long Date { get; set; }
		public long Updated { get; set; }
	}
}