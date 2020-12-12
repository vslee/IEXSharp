using System;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Model.CoreData.StockFundamentals.Response
{
	public class DividendBasicResponse : Dividend
	{
		public long? date { get; set; }
		public long updated { get; set; }
	}
}