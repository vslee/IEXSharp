using System.ComponentModel;

namespace IEXSharp.Model.EconomicData.Request
{
	public enum EconomicDataSymbol
	{
		/// <summary>
		/// CD Rate Non-Jumbo less than $100,000 Money market
		/// </summary>
		[Description("MMNRNJ")]
		MMNRNJ,

		/// <summary>
		/// CD Rate Jumbo more than $100,000 Money market
		/// </summary>
		[Description("MMNRJD")]
		MMNRJD,

		/// <summary>
		/// Consumer Price Index All Urban Consumers
		/// </summary>
		[Description("CPIAUCSL")]
		CPIAUCSL,

		/// <summary>
		/// Commercial bank credit card interest rate as a percent, not seasonally adjusted
		/// </summary>
		[Description("TERMCBCCALLNS")]
		TERMCBCCALLNS,

		/// <summary>
		/// Effective federal funds rate
		/// </summary>
		[Description("FEDFUNDS")]
		FEDFUNDS,

		/// <summary>
		/// Real Gross Domestic Product
		/// </summary>
		[Description("A191RL1Q225SBEA")]
		A191RL1Q225SBEA,

		/// <summary>
		/// Institutional money funds returned as billions of dollars,seasonally adjusted
		/// </summary>
		[Description("WIMFSL")]
		WIMFSL,

		/// <summary>
		/// Initial Claims 4 week moving average, seasonally adjusted
		/// </summary>
		[Description("IC4WSA")]
		IC4WSA,

		/// <summary>
		/// Industrial Production Index
		/// </summary>
		[Description("INDPRO")]
		INDPRO,

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
		/// Total nonfarm employees in thousands of persons seasonally adjusted
		/// </summary>
		[Description("PAYEMS")]
		PAYEMS,

		/// <summary>
		/// Total Vehicle Sales in millions of units
		/// </summary>
		[Description("TOTALSA")]
		TOTALSA,

		/// <summary>
		/// Retail money funds returned as billions of dollars, seasonally adjusted
		/// </summary>
		[Description("WRMFSL")]
		WRMFSL,

		/// <summary>
		/// Retail money funds returned as billions of dollars, seasonally adjusted
		/// </summary>
		[Description("UNRATE")]
		UNRATE,

		/// <summary>
		/// US Recession Probabilities. Smoothed recession probabilities for the United States are obtained
		/// from a dynamic-factor markov-switching model applied to four monthly coincident variables:
		/// non-farm payroll employment, the index of industrial production, real personal income excluding
		/// transfer payments, and real manufacturing and trade sales.
		/// </summary>
		[Description("RECPROUSM156N")]
		RECPROUSM156N,
	}
}