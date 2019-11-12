using System;

namespace IEXSharp.Model.Stock.Response
{
    public class SplitV1
    {
        public DateTime exDate { get; set; }
        public DateTime declaredDate { get; set; }
        public DateTime recordDate { get; set; }
        public DateTime paymentDate { get; set; }
        public double ratio { get; set; }
        public int toFactor { get; set; }
        public int forFactor { get; set; }
    }

    public class Split
    {
        public DateTime exDate { get; set; }
        public DateTime declaredDate { get; set; }
        public decimal ratio { get; set; }
        public int toFactor { get; set; }
        public int fromFactor { get; set; }
        public string description { get; set; }
    }
}