using System;

namespace IEXSharp.Model.PremiumData.WallStreetHorizon.Response
{
	public class BuybacksResponse
	{
		public string EventId { get; set; }
		public string RecordType { get; set; }
		public string Symbol { get; set; }
		public string CompanyName { get; set; }
		public string BuybackStatus { get; set; }
		public string BuybackMethod { get; set; }
		public DateTime AnnounceDate { get; set; }
		public DateTime? ApprovalDate { get; set; }
		public string NumberOfShares { get; set; }
		public string SharesDifferent { get; set; }
		public string PercentOfShares { get; set; }
		public string ShareValue { get; set; }
		public string ShareValueCurrency { get; set; }
		public string ValueDifferent { get; set; }
		public string EndDate { get; set; }
		public string PriceFrom { get; set; }
		public string PriceTo { get; set; }
		public string TenderResult { get; set; }
		public string TenderExpiration { get; set; }
		public string NewsReferences { get; set; }
		public string ExternalNotes { get; set; }
		public string Created { get; set; }
		public long Updated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public long Date { get; set; }
	}
}