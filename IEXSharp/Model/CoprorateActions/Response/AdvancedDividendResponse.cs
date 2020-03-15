using System;

namespace IEXSharp.Model.CoprorateActions.Response
{
	public class AdvancedDividendResponse
	{
		public string symbol { get; set; }
		public DateTime? exDate { get; set; }
		public DateTime? recordDate { get; set; }
		public DateTime? paymentDate { get; set; }
		public DateTime? announceDate { get; set; }
		public string currency { get; set; }
		public string frequency { get; set; }
		public double amount { get; set; }
		public string description { get; set; }
		public string flag { get; set; }
		public string securityType { get; set; }
		public string notes { get; set; }
		public string figi { get; set; }
		public DateTime? lastUpdated { get; set; }
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
		public DateTime? fxDate { get; set; }
		public DateTime? secondPaymentDate { get; set; }
		public DateTime? secondExDate { get; set; }
		public DateTime? fiscalYearEndDate { get; set; }
		public DateTime? periodEndDate { get; set; }
		public DateTime? optionalElectionDate { get; set; }
		public DateTime? toDate { get; set; }
		public DateTime? registrationDate { get; set; }
		public DateTime? installmentPayDate { get; set; }
		public DateTime? declaredDate { get; set; }
		public string refid { get; set; }
		public string created { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long updated { get; set; }
	}
}
