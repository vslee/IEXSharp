using System.Collections.Generic;

namespace VSLee.IEXSharp.Model.Account.Response
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
		public Dictionary<string, long> dailyUsage { get; set; }
		public Dictionary<string, long> tokenUsage { get; set; }
		public UsageResponseKeyUsage keyUsage { get; set; }
	}

	public class UsageResponseKeyUsage
	{
		public long IEX_TOPS { get; set; }
		public int COMPANY { get; set; }
		public long IEX_STATS { get; set; }
		public long EARNINGS { get; set; }
		public long STOCK_QUOTES { get; set; }
	}
}