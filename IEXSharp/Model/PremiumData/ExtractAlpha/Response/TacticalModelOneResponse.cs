using System;

namespace IEXSharp.Model.PremiumData.ExtractAlpha.Response
{
	public class TacticalModelOneResponse
	{
		public decimal ReversalComponent { get; set; }
		public decimal FactorMomentumComponent { get; set; }
		public decimal LiquidityShockComponent { get; set; }
		public decimal SeasonalityComponent { get; set; }
		public decimal Tm1 { get; set; }
		public decimal updated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public DateTime Subkey { get; set; }
		public long Date { get; set; }
	}
}