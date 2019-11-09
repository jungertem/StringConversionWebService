using System.Web.Http;

namespace MyWebService.Controllers
{
    public class DecoderController : ApiController
    {
        [HttpGet]
        public string DecodeXml(string textValue)
        {
            if (string.IsNullOrEmpty(textValue))
            {
                return "NoValueEntered";
            }

            XMLOperations xml = new XMLOperations();
            string result = xml.Decode(textValue);

            return result;
        }

        [HttpGet]
        public string EncodeXml(string textValue)
        {
            if (string.IsNullOrEmpty(textValue))
            {
                return "NoValueEntered";
            }

            XMLOperations xml = new XMLOperations();
            string result = xml.Encode(textValue);

            return result;
        }

        [HttpGet]
        public string EscapeJSON(string textValue)
        {
            if (string.IsNullOrEmpty(textValue))
            {
                return "NoValueEntered";
            }

            JSONOperations json = new JSONOperations();
            string result = json.Escape(textValue);

            return result;
        }

        [HttpGet]
        public string UnEscapeJSON(string textValue)
        {
            if (string.IsNullOrEmpty(textValue))
            {
                return "NoValueEntered";
            }

            JSONOperations json = new JSONOperations();
            string result = json.UnEscape(textValue);

            return result;
        }
    }
}
