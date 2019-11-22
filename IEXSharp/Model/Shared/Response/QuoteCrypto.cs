using System;
using System.Collections.Generic;
using System.Text;

namespace VSLee.IEXSharp.Model.Shared.Response
{
	public class QuoteCrypto
	{
		public string symbol { get; set; }
		public string sector { get; set; }
		public string calculationPrice { get; set; }
		public decimal latestPrice { get; set; }
		public string latestSource { get; set; }
		public long latestUpdate { get; set; }
		public decimal? latestVolume { get; set; }
		public decimal bidPrice { get; set; }
		public decimal bidSize { get; set; }
		public decimal askPrice { get; set; }
		public decimal askSize { get; set; }
		public decimal? high { get; set; }
		public decimal? low { get; set; }
		public decimal? previousClose { get; set; }

		public override string ToString() =>
			$"{symbol},{latestUpdate},{latestPrice},{latestVolume}";
	}
}
