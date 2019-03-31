namespace IEXClient.Model.AlternativeData.Response
{
    public class CEOCompensationResponse
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string companyName { get; set; }
        public string location { get; set; }
        public long salary { get; set; }
        public long bonus { get; set; }
        public long stockAwards { get; set; }
        public long optionAwards { get; set; }
        public long nonEquityIncentives { get; set; }
        public long pensionAndDeferred { get; set; }
        public long otherComp { get; set; }
        public long total { get; set; }
        public string year { get; set; }
    }
}