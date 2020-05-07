using System.ComponentModel;

namespace IEXSharp.Model.EconomicData.Request
{
	public enum EconomicDataTimeSeriesSymbol
	{
		/// <summary>
		/// Real Gross Domestic Product
		/// </summary>
		[Description("A191RL1Q225SBEA")]
		A191RL1Q225SBEA,

		/// <summary>
		/// US 30-Year fixed rate mortgage average
		/// </summary>
		[Description("MORTGAGE30US")]
		MORTGAGE30US,

		/// <summary>
		/// US 15-Year fixed rate mortgage average
		/// </summary>
		[Description("MORTGAGE15US")]
		MORTGAGE15US,

		/// <summary>
		/// US 5/1-Year adjustable rate mortgage average
		/// </summary>
		[Description("MORTGAGE5US")]
		MORTGAGE5US,

		/// <summary>
		/// Total Housing Starts in thousands of units, seasonally adjusted annual rate
		/// </summary>
		[Description("HOUST")]
		HOUST,

		/// <summary>
		/// Retail money funds returned as billions of dollars, seasonally adjusted
		/// </summary>
		[Description("UNRATE")]
		UNRATE,
	}
}