namespace IEXClient.Model.Shared.Response
{
    public class Dividend
    {
        public string exDate { get; set; }
        public string paymentDate { get; set; }
        public string recordDate { get; set; }
        public string declaredDate { get; set; }
        public decimal amount { get; set; }
        public string flag { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public string frequency { get; set; }
    }
}