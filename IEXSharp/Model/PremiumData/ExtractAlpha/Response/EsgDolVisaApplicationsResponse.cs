using System;

namespace IEXSharp.Model.PremiumData.ExtractAlpha.Response
{
	public class EsgDolVisaApplicationsResponse
	{
		public string EventId { get; set; }
		public string MasterName { get; set; }
		public string EmployerName { get; set; }
		public string CaseNumber { get; set; }
		public string JobTitle { get; set; }
		public string TotalWorkers { get; set; }
		public string Type { get; set; }
		public string DcaseSubmitted { get; set; }
		public DateTime? DemploymentStartDate { get; set; }
		public DateTime? DemploymentEndDate { get; set; }
		public string CaseStatus { get; set; }
		public decimal updated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public DateTime Subkey { get; set; }
		public long Date { get; set; }
	}
}