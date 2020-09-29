using System;

namespace IEXSharp.Model.Shared.Response
{
	public enum DividendFlag : byte
	{
		Cash = 2, DividendIncome = 4,
	}

	public enum DividendFrequency : byte
	{
		quarterly = 2,
	}

	public class Dividend
	{
		public DateTime exDate { get; set; }
		public DateTime? paymentDate { get; set; }
		public DateTime recordDate { get; set; }
		public DateTime? declaredDate { get; set; }
		public decimal? amount { get; set; }
		public string flag { get; set; }
		public DividendFlag DividendFlag =>
			(DividendFlag)Enum.Parse(typeof(DividendFlag), flag);
		public string currency { get; set; }
		public string description { get; set; }
		public string frequency { get; set; }
		public string symbol { get; set; }
		public DividendFrequency DividendFrequency =>
			(DividendFrequency)Enum.Parse(typeof(DividendFrequency), frequency);
	}
}