//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using MyWebService.Controllers;

namespace MyWebService.Tests
{
    [TestFixture]
    public class ConversionTests
    {
        [Test]
        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase("Joe&apos;s Caf&#233; &amp; Bar &#9835;", "Joe's Café & Bar ♫")]
        [TestCase("&lt;Hello&gt;\n&lt;World&gt;", "<Hello>\n<World>")]
        [TestCase("&lt;another test&gt;", "<another test>")]
        [TestCase("`1234567890-=qwertyuiop[]asdfghjkl;&apos;zxcvbnm,./&lt;&gt;", "`1234567890-=qwertyuiop[]asdfghjkl;'zxcvbnm,./<>")]
        public void DecodingXML(string input, string expected)
        {
            XMLOperations xml = new XMLOperations();
            string result = xml.Decode(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase("Joe's Café & Bar ♫", "Joe&apos;s Caf&#233; &amp; Bar &#9835;")]
        [TestCase("<Hello>\n<World>", "&lt;Hello&gt;\n&lt;World&gt;")]
        [TestCase( "<another test>", "&lt;another test&gt;")]
        [TestCase("`1234567890-=qwertyuiop[]asdfghjkl;'zxcvbnm,./<>", "`1234567890-=qwertyuiop[]asdfghjkl;&apos;zxcvbnm,./&lt;&gt;")]
        public void EncodingXML(string input, string expected)
        {
            XMLOperations xml = new XMLOperations();
            string result = xml.Encode(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase("\"", @"\" + "\"")]
        [TestCase(@"\t\n\r", @"\\t\\n\\r")]
        [TestCase(@"\\\\\", @"\\\\\\\\\\")]
        [TestCase("<Hello>\n<World>", @"<Hello>\r\n<World>")]
        [TestCase("tabulation \t tabulation\nnew line", @"tabulation \t tabulation\r\nnew line")]
        public void EscapingJSON(string input, string expected)
        {
            JSONOperations json = new JSONOperations();
            var result = json.Escape(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase(@"tabulation \t tabulation\r\nnew line", "tabulation \t tabulation\nnew line")]
        [TestCase(@"<Word1>\r\n<Word2>", "<Word1>\n<Word2>")]
        public void UnescapingJson(string input, string expected)
        {
            JSONOperations json = new JSONOperations();
            var result = json.UnEscape(input);

            Assert.AreEqual(expected, result);
        }

    }
}
