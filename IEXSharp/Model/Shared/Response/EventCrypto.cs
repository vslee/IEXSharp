using System;
using System.Collections.Generic;
using System.Text;

namespace VSLee.IEXSharp.Model.Shared.Response
{
	public class EventCrypto
	{
		public string symbol { get; set; }
		public string eventType { get; set; }
		public long timestamp { get; set; }
		public string reason { get; set; }
		public decimal price { get; set; }
		public decimal size { get; set; }
		public string side { get; set; }

		public override string ToString() =>
			$"{symbol},{eventType},{timestamp},{price}";
	}
}
