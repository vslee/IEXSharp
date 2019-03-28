namespace IEX.V2.Model.Stock.Response
{
    public class Split
    {
        public string exDate { get; set; }
        public string declaredDate { get; set; }
        public decimal ratio { get; set; }
        public int toFactor { get; set; }
        public int fromFactor { get; set; }
        public string description { get; set; }
    }
}