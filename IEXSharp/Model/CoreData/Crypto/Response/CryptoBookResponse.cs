using System.Collections.Generic;

namespace IEXSharp.Model.CoreData.Crypto.Response
{
	public class CryptoBookResponse
	{
		public List<CryptoBookQuote> bids { get; set; }
		public List<CryptoBookQuote> asks { get; set; }
	}
}