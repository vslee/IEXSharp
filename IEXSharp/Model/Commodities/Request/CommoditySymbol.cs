using System;
using System.ComponentModel;

namespace IEXSharp.Model.Commodities.Request
{
	public enum CommoditySymbol
	{
		/// <summary>
		/// Crude oil West Texas Intermediate - in dollars per barrel,
		/// not seasonally adjusted
		/// </summary>
		[Description("DCOILWTICO")]
		DCOILWTICO,

		/// <summary>
		/// Crude oil Brent Europe - in dollars per barrel,
		/// not seasonally adjusted
		/// </summary>
		[Description("DCOILBRENTEU")]
		DCOILBRENTEU,

		/// <summary>
		/// Henry Hub Natural Gas Spot Price - in dollars per million BTU,
		/// not seasonally adjusted
		/// </summary>
		[Description("DHHNGSP")]
		DHHNGSP,

		/// <summary>
		/// No. 2 Heating Oil New York Harbor - in dollars per gallon,
		/// not seasonally adjusted
		/// </summary>
		[Description("DHOILNYH")]
		DHOILNYH,

		/// <summary>
		/// Kerosense Type Jet Fuel US Gulf Coast - in dollars per gallon,
		/// not seasonally adjusted
		/// </summary>
		[Description("DJFUELUSGULF")]
		DJFUELUSGULF,

		/// <summary>
		/// US Diesel Sales Price - in dollars per gallon,
		/// not seasonally adjusted
		/// </summary>
		[Description("GASDESW")]
		GASDESW,

		/// <summary>
		/// US Regular Conventional Gas Price - in dollars per gallon,
		/// not seasonally adjusted
		/// </summary>
		[Description("GASREGCOVW")]
		GASREGCOVW,

		/// <summary>
		/// US Midgrade Conventional Gas Price - in dollars per gallon,
		/// not seasonally adjusted
		/// </summary>
		[Description("GASMIDCOVW")]
		GASMIDCOVW,

		/// <summary>
		/// US Premium Conventional Gas Price - in dollars per gallon,
		/// not seasonally adjusted
		/// </summary>
		[Description("GASPRMCOVW")]
		GASPRMCOVW,

		/// <summary>
		/// Propane Prices Mont Belvieu Texas - in dollars per gallon,
		/// not seasonally adjusted
		/// </summary>
		[Description("DPROPANEMBTX")]
		DPROPANEMBTX
	}
}
