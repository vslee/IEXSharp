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
		public DividendFlag DividendFlag =>
			(DividendFlag)Enum.Parse(typeof(DividendFlag), flag);
		public string currency { get; set; }
		public string description { get; set; }
		public string frequency { get; set; }
		public Frequency Frequency =>
			(Frequency)Enum.Parse(typeof(Frequency), frequency);
	}

	public class AdvancedDividend
	{
		public string symbol { get; set; }
		public string exDate { get; set; }
		public string recordDate { get; set; }
		public string paymentDate { get; set; }
		public string announceDate { get; set; }
		public string currency { get; set; }
		public string frequency { get; set; }
		public double amount { get; set; }
		public string description { get; set; }
		public string flag { get; set; }
		public string securityType { get; set; }
		public object notes { get; set; }
		public string figi { get; set; }
		public string lastUpdated { get; set; }
		public string countryCode { get; set; }
		public double parValue { get; set; }
		public string parValueCurrency { get; set; }
		public int netAmount { get; set; }
		public double grossAmount { get; set; }
		public string marker { get; set; }
		public int taxRate { get; set; }
		public int fromFactor { get; set; }
		public int toFactor { get; set; }
		public int adrFee { get; set; }
		public int coupon { get; set; }
		public string declaredCurrencyCD { get; set; }
		public int declaredGrossAmount { get; set; }
		public int isCapitalGains { get; set; }
		public int isNetInvestmentIncome { get; set; }
		public int isDAP { get; set; }
		public int isApproximate { get; set; }
		public object fxDate { get; set; }
		public object secondPaymentDate { get; set; }
		public object secondExDate { get; set; }
		public string fiscalYearEndDate { get; set; }
		public string periodEndDate { get; set; }
		public object optionalElectionDate { get; set; }
		public object toDate { get; set; }
		public object registrationDate { get; set; }
		public object installmentPayDate { get; set; }
		public string declaredDate { get; set; }
		public string refid { get; set; }
		public string created { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long updated { get; set; }
	}
}