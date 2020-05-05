using System.ComponentModel;

namespace IEXSharp.Model.MarketInfo.Request
{
	public enum ListType
	{
		[Description("mostactive")]
		MostActive,
		[Description("gainers")]
		Gainers,
		[Description("losers")]
		Losers,
		[Description("iexvolume")]
		IexVolume,
		[Description("iexpercent")]
		IexPercent,
	}
}