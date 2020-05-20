namespace IEXSharp.Model.PremiumData.PrecisionAlpha.Response
{
	public class PriceDynamicsResponse
	{
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public string Symbol { get; set; }
		public string CompanyName { get; set; }
		public string CloseDate { get; set; }
		public decimal ProbabilityUp { get; set; }
		public decimal ProbabilityDown { get; set; }
		public decimal MarketEmotion { get; set; }
		public decimal MarketPower { get; set; }
		public decimal MarketResistance { get; set; }
		public decimal MarketNoise { get; set; }
		public string Date { get; set; }
		public string Updated { get; set; }
	}
}