using System.Text.RegularExpressions;
using System.Text;

namespace MyWebService.Controllers
{
    public class JSONOperations
    {
        public string Escape(string toEscape)
        {
            if (toEscape == null)
            {
                return null;
            }

            StringBuilder result = new StringBuilder(toEscape);

            result.Replace(@"\", @"\\");
            result.Replace("\n", @"\r\n");
            result.Replace("\t", @"\t");
            result.Replace("\r", @"\r");
            result.Replace("\b", @"\b");
            result.Replace("\f", @"\f");
            result.Replace("\t", @"\t");
            result.Replace("/", @"\/");
            result.Replace("\"", @"\" + "\"");

            return result.ToString();
        }
        public string UnEscape(string toUnEscape)
        {
            if (toUnEscape == null)
            {
                return null;
            }

            StringBuilder result = new StringBuilder(toUnEscape);
           
            result.Replace(@"\" + @"""", @"""");
            result.Replace(@"\r\n", "\n");
            result.Replace(@"\r", "\r");
            result.Replace(@"\n", "\n");
            result.Replace(@"\t", "\t");
            result.Replace(@"\b", "\b");
            result.Replace(@"\f", "\f");
            result.Replace(@"\t", "\t");
            result.Replace(@"\/", "/");
            result.Replace(@"\\", @"\");

            return result.ToString();
        }
    }
}
