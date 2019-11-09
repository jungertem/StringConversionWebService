namespace MyWebService.Controllers
{
    public class XMLOperations
    {
        public string Encode(string toEncode)
        {
            toEncode = toEncode ?? string.Empty;

            string final = "";
            foreach (char symbol in toEncode)
            {
                final += $"&#{(int)symbol};";
            }

            return final;
        }

        public string Decode(string toDecode)
        {
            toDecode = toDecode ?? string.Empty;
            string checking = System.Net.WebUtility.HtmlDecode(toDecode);

            return checking;
        }
    }
}
