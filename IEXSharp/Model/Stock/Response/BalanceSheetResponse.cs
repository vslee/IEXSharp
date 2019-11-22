using System;
using System.Collections.Generic;

namespace VSLee.IEXSharp.Model.Stock.Response
{
	public class BalanceSheetResponse
	{
		public string symbol { get; set; }
		public List<Balancesheet> balancesheet { get; set; }
	}

	public class Balancesheet
	{
		public DateTime reportDate { get; set; }
		public long currentCash { get; set; }
		public long shortTermInvestments { get; set; }
		public long receivables { get; set; }
		public long inventory { get; set; }
		public long otherCurrentAssets { get; set; }
		public long currentAssets { get; set; }
		public long longTermInvestments { get; set; }
		public long propertyPlantEquipment { get; set; }
		public long goodwill { get; set; }
		public long intangibleAssets { get; set; }
		public long otherAssets { get; set; }
		public long totalAssets { get; set; }
		public long accountsPayable { get; set; }
		public long currentLongTermDebt { get; set; }
		public long otherCurrentLiabilities { get; set; }
		public long totalCurrentLiabilities { get; set; }
		public long longTermDebt { get; set; }
		public long otherLiabilities { get; set; }
		public long minorityInterest { get; set; }
		public long totalLiabilities { get; set; }
		public long commonStock { get; set; }
		public long retainedEarnings { get; set; }
		public long treasuryStock { get; set; }
		public long capitalSurplus { get; set; }
		public long shareholderEquity { get; set; }
		public long netTangibleAssets { get; set; }
	}
}