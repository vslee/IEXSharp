using System.ComponentModel;

namespace IEXSharp.Model.CoreData.Treasuries.Request
{
	public enum TreasuryRateSymbol
	{
		/// <summary>
		/// 30 Year constant maturity rate
		/// </summary>
		[Description("DGS30")]
		DGS30,
		/// <summary>
		/// 20 Year constant maturity rate
		/// </summary>
		[Description("DGS20")]
		DGS20,
		/// <summary>
		/// 10 Year constant maturity rate
		/// </summary>
		[Description("DGS10")]
		DGS10,
		/// <summary>
		/// 5 Year constant maturity rate
		/// </summary>
		[Description("DGS5")]
		DGS5,
		/// <summary>
		/// 2 Year constant maturity rate
		/// </summary>
		[Description("DGS2")]
		DGS2,
		/// <summary>
		/// 1 Year constant maturity rate
		/// </summary>
		[Description("DGS1")]
		DGS1,
		/// <summary>
		/// 6 Month constant maturity rate
		/// </summary>
		[Description("DGS6MO")]
		DGS6MO,
		/// <summary>
		/// 3 Month constant maturity rate
		/// </summary>
		[Description("DGS3MO")]
		DGS3MO,
		/// <summary>
		/// 1 Month constant maturity rate
		/// </summary>
		[Description("DGS1MO")]
		DGS1MO
	}
}
