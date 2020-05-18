namespace IEXSharp.Model.CoreData.CeoCompensation.Response
{
	public class CeoCompensationResponse
	{
		public string symbol { get; set; }
		public string name { get; set; }
		public string companyName { get; set; }
		public string location { get; set; }
		public decimal salary { get; set; }
		public decimal bonus { get; set; }
		public decimal stockAwards { get; set; }
		public decimal optionAwards { get; set; }
		public decimal nonEquityIncentives { get; set; }
		public decimal pensionAndDeferred { get; set; }
		public decimal otherComp { get; set; }
		public decimal total { get; set; }
		public string year { get; set; }
	}
}
