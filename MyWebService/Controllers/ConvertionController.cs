using System.Web.Http;

namespace MyWebService.Controllers
{
    public class ConvertionController : ApiController
    {
        XMLOperations xml = new XMLOperations();
        JSONOperations json = new JSONOperations();

        [HttpGet]
        public string DecodeXml(string textValue)
        {
            return string.IsNullOrEmpty(textValue) ? "NoValueEntered" : xml.Decode(textValue);
        }

        [HttpGet]
        public string EncodeXml(string textValue)
        {
            return string.IsNullOrEmpty(textValue) ? "NoValueEntered" : xml.Encode(textValue);
        }

        [HttpGet]
        public string EscapeJSON(string textValue)
        {
            return string.IsNullOrEmpty(textValue) ? "NoValueEntered" : json.Escape(textValue);
        }

        [HttpGet]
        public string UnEscapeJSON(string textValue)
        {
            return string.IsNullOrEmpty(textValue) ? "NoValueEntered" : json.UnEscape(textValue);
        }
    }
}
