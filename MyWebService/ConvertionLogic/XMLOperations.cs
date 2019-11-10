using System.Text;
using System.Text.RegularExpressions;

namespace MyWebService.Controllers
{
    public class XMLOperations
    {
        public string Encode(string toEncode)
        {
            if (toEncode == null)
            {
                return null;
            }

            StringBuilder temporary = new StringBuilder(toEncode);
            
            temporary.Replace("&", "&amp;");
            temporary.Replace(">", "&gt;");
            temporary.Replace("<", "&lt;");
            temporary.Replace("\"", "&quot;");
            temporary.Replace("'", "&apos;");

            // detecting and replacing all non-ascii characters from temporary string;
            string asciiLine = Regex.Replace(temporary.ToString(), @"[^\u0000-\u007F]", val => "&#" + ((int)char.Parse(val.Value)).ToString() + ";");

            return asciiLine;
        }

        public string Decode(string toDecode)
        {
            return toDecode == null ? null : System.Net.WebUtility.HtmlDecode(toDecode);
        }
    }
}
