using System;

namespace IEXSharp.Model.Shared.Response
{
	public enum DividendFlag : byte
	{
		Null = 0,
		Cash = 2,
		DividendIncome = 4,
		Stock = 8,
		Unknown = 255
	}

	public enum DividendFrequency : byte
	{
		quarterly = 2,
		Null,
		Unknown
	}

	public class Dividend
	{
		public DateTime exDate { get; set; }
		public DateTime? paymentDate { get; set; }
		public DateTime recordDate { get; set; }
		public DateTime? declaredDate { get; set; }
		public decimal? amount { get; set; }
		public string flag { get; set; }
		public DividendFlag DividendFlag
		{
			get
			{
				if ((flag ?? "") == "")
				{
					return DividendFlag.Null;
				}
				return Enum.TryParse<DividendFlag>(flag, out var result)
					? result
					: DividendFlag.Unknown;
			}
		}

		public string currency { get; set; }
		public string description { get; set; }
		public string frequency { get; set; }
		public string symbol { get; set; }
		public DividendFrequency DividendFrequency
		{
			get
			{
				if ((frequency ?? "") == "")
				{
					return DividendFrequency.Null;
				}
				return Enum.TryParse<DividendFrequency>(frequency, out var result) ? result : DividendFrequency.Unknown;
			}
		}
	}
}