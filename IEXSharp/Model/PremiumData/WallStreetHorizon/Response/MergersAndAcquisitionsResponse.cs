using System;

namespace IEXSharp.Model.PremiumData.WallStreetHorizon.Response
{
	public class MergersAndAcquisitionsResponse
	{
		public string acquirerCompanyId { get; set; }
		public string acquirerName { get; set; }
		public string acquirerSymbol { get; set; }
		public string actionNotes { get; set; }
		public string actionStatus { get; set; }
		public string actionType { get; set; }
		public DateTime announceDate { get; set; }
		public DateTime? closeDate { get; set; }
		public string etFlag { get; set; }
		public string eventId { get; set; }
		public string newsReferences { get; set; }
		public string purchasePriceSharesNumber { get; set; }
		public string srFlag  { get; set; }
		public string targetCompanyId { get; set; }
		public string targetName { get; set; }
		public string targetSymbol { get; set; }
		public decimal updated { get; set; }
		public string id { get; set; }
		public string source { get; set; }
		public string key { get; set; }
		public string subkey  { get; set; }
	}
}