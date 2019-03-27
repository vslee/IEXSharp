using System.Collections.Specialized;
using System.Web;

namespace IEX.V2.Helper
{
    public class QueryStringBuilder
    {
        private NameValueCollection nvc;

        public QueryStringBuilder()
        {
            nvc = HttpUtility.ParseQueryString(string.Empty);
        }

        public void Add(string name, object value)
        {
            var val = value.ToString().Trim();
            if (!string.IsNullOrEmpty(name))
            {
                nvc.Add(name, val);
            }
        }

        public void Remove(string name)
        {
            nvc.Remove(name);
        }

        public string Build()
        {
            return "?" + nvc.ToString();
        }
    }
}