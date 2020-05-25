using System;

namespace IEXSharp.Model.CoreData.ReferenceData.Response
{
	/// <summary>
	/// Legacy
	/// </summary>
	public class IEXNextDayExDateResponse
	{
		public string RecordID { get; set; }
		public DateTime DailyListTimestamp { get; set; }
		public string ExDate { get; set; }
		public string SymbolinINETSymbology { get; set; }
		public string SymbolinCQSSymbology { get; set; }
		public string SymbolinCMSSymbology { get; set; }
		public string SecurityName { get; set; }
		public string CompanyName { get; set; }
		public string DividendTypeID { get; set; }
		public string AmountDescription { get; set; }
		public string PaymentFrequency { get; set; }
		public string StockAdjustmentFactor { get; set; }
		public string StockAmount { get; set; }
		public string CashAmount { get; set; }
		public string PostSplitShares { get; set; }
		public string PreSplitShares { get; set; }
		public string QualifiedDividend { get; set; }
		public string ExercisePriceAmount { get; set; }
		public string ElectionorExpirationDate { get; set; }
		public string GrossAmount { get; set; }
		public string NetAmount { get; set; }
		public string BasisNotes { get; set; }
		public string NotesforEachEntry { get; set; }
		public DateTime RecordUpdateTime { get; set; }
	}
}