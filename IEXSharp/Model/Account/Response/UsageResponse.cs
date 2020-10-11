using System;
using System.Collections.Generic;

namespace IEXSharp.Model.Account.Response
{
	public class UsageResponse
	{
		public UsageResponseMessages messages { get; set; }
		public List<object> rules { get; set; }
	}

	public class UsageResponseMessages
	{
		public long monthlyUsage { get; set; }
		public long monthlyPayAsYouGo { get; set; }
		public Dictionary<DateTime, string> dailyUsage { get; set; }
		public Dictionary<string, string> tokenUsage { get; set; }
		public Dictionary<string, string> keyUsage { get; set; }
	}
}