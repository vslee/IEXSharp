using System;

namespace IEXSharp.Model.PremiumData.ExtractAlpha.Response
{
	public class EsgUsaSpendingResponse
	{
		public string EventId { get; set; }
		public string MasterName { get; set; }
		public string VendorName { get; set; }
		public string VendorAlternateName { get; set; }
		public string VendorLegalOrganizationName { get; set; }
		public string VendorDoingBusinessAsName { get; set; }
		public string DivisionName { get; set; }
		public string ModParent { get; set; }
		public string UniqueTransactionId { get; set; }
		public string DollarsObligated { get; set; }
		public DateTime SignedDate { get; set; }
		public string MajAgencyCat { get; set; }
		public decimal updated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public DateTime Subkey { get; set; }
		public long Date { get; set; }
	}
}