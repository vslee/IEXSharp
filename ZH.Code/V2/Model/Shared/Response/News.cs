using System;
using System.Collections.Generic;
using System.Text;

namespace ZH.Code.IEX.V2.Model.Shared.Response
{
    public class News
    {
        public long datetime { get; set; }
        public string headline { get; set; }
        public string source { get; set; }
        public string url { get; set; }
        public string summary { get; set; }
        public string related { get; set; }
        public string image { get; set; }
        public string lang { get; set; }
        public bool hasPaywall { get; set; }
    }
}
