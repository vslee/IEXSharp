using System;

namespace VSLee.IEXSharp.Model.Shared.Response
{
	public enum DividendFlag : byte
	{
		Cash = 2, DividendIncome = 4,
	}

	public enum Frequency : byte
	{
		Quarterly = 2,
	}

	public class DividendV1
	{
		public DateTime exDate { get; set; }
		public DateTime paymentDate { get; set; }
		public DateTime recordDate { get; set; }
		public DateTime declaredDate { get; set; }
		public decimal amount { get; set; }
		public string flag { get; set; }
		public string type { get; set; }
		public string qualified { get; set; }
		public decimal indicated { get; set; }
	}

	public class Dividend
	{
		public DateTime exDate { get; set; }
		public DateTime paymentDate { get; set; }
		public DateTime recordDate { get; set; }
		public DateTime declaredDate { get; set; }
		public decimal amount { get; set; }
		public string flag { get; set; }
		public DividendFlag DividendFlag => Enum.Parse(typeof(DividendFlag), flag);
		public string currency { get; set; }
		public string description { get; set; }
		public string frequency { get; set; }
		public Frequency Frequency { get; set; }
	}
}