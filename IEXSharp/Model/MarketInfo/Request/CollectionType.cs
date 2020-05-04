using System.ComponentModel;

namespace VSLee.IEXSharp.Model.MarketInfo.Request
{
	public enum CollectionType
	{
		[Description("sector")]
		Sector,
		[Description("tag")]
		Tag,
		[Description("list")]
		List
	}
}