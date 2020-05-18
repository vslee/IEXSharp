using System;
using IEXSharp.Model.Shared.Response;

namespace IEXSharp.Model.CoreData.StockFundamentals.Response
{
	public class DividendV1Response : DividendV1 { }

	public class DividendBasicResponse : Dividend
	{
		public DateTime date { get; set; }
	}
}