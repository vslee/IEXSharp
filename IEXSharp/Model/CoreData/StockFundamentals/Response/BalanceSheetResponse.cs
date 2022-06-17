using System;
using System.Collections.Generic;

namespace IEXSharp.Model.CoreData.StockFundamentals.Response
{
	public class BalanceSheetResponse
	{
		public string symbol { get; set; }
		public List<Balancesheet> balancesheet { get; set; }
	}

	public class Balancesheet
	{
		public DateTime? reportDate { get; set; }
		public DateTime? fiscalDate { get; set; }
		public int fiscalQuarter { get; set; }
		public int fiscalYear { get; set; }
		public string currency { get; set; }
		public decimal? currentCash { get; set; }
		public decimal? shortTermInvestments { get; set; }
		public decimal? receivables { get; set; }
		public decimal? inventory { get; set; }
		public decimal? otherCurrentAssets { get; set; }
		public decimal? currentAssets { get; set; }
		public decimal? longTermInvestments { get; set; }
		public decimal? propertyPlantEquipment { get; set; }
		public decimal? goodwill { get; set; }
		public decimal? intangibleAssets { get; set; }
		public decimal? otherAssets { get; set; }
		public decimal? totalAssets { get; set; }
		public decimal? accountsPayable { get; set; }
		public decimal? currentLongTermDebt { get; set; }
		public decimal? otherCurrentLiabilities { get; set; }
		public decimal? totalCurrentLiabilities { get; set; }
		public decimal? longTermDebt { get; set; }
		public decimal? otherLiabilities { get; set; }
		public decimal? minorityInterest { get; set; }
		public decimal? totalLiabilities { get; set; }
		public decimal? commonStock { get; set; }
		public decimal? retainedEarnings { get; set; }
		public decimal? treasuryStock { get; set; }
		public decimal? capitalSurplus { get; set; }
		public decimal? shareholderEquity { get; set; }
		public decimal? netTangibleAssets { get; set; }
		public string id { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
		public decimal updated { get; set; }
	}
}