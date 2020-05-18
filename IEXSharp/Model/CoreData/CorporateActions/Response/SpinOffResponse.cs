using System;

namespace IEXSharp.Model.CoreData.CorporateActions.Response
{
	public class SpinOffResponse : CorporateActionResponse
	{
	    public DateTime? withdrawalFromDate { get; set; }
	    public DateTime? withdrawalToDate { get; set; }
	    public DateTime? electionDate { get; set; }
	    public DateTime? effectiveDate { get; set; }
	    public double minPrice { get; set; }
	    public double maxPrice { get; set; }
	    public int hasWithdrawalRights { get; set; }
	    public string currency { get; set; }
	}
}