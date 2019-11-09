using System.Text.RegularExpressions;

namespace MyWebService.Controllers
{
    public class JSONOperations
    {
        public string Escape(string toEscape)
        {
            toEscape = toEscape ?? string.Empty;
            toEscape = Regex.Escape(toEscape);

            return toEscape;
        }
        public string UnEscape(string toUnEscape)
        {
            toUnEscape = toUnEscape ?? string.Empty;
            toUnEscape = Regex.Unescape(toUnEscape);

            return toUnEscape;
        }
    }
}
