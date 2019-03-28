using System.Collections.Generic;

namespace ZH.Code.IEX.V2.Model.Stock.Response
{
    public class CompanyResponse
    {
        public string symbol { get; set; }
        public string companyName { get; set; }
        public string exchange { get; set; }
        public string industry { get; set; }
        public string website { get; set; }
        public string description { get; set; }
        public string CEO { get; set; }
        public string issueType { get; set; }
        public string sector { get; set; }
        public List<string> tags { get; set; }
    }
}