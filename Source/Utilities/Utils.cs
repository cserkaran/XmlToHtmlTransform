using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace Utilities
{
    /// <summary>
    /// Helper class containing utility method's to be used 
    /// accross the application.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Transforms the XML to HTML.
        /// </summary>
        /// <param name="inputXml">The xml text.</param>
        /// <param name="xsltString">The XSLT text.</param>
        /// <returns>the transformed html text.</returns>
        public static string TransformXMLToHTML(string inputXml, string xslt)
        {
            XslCompiledTransform transform = new XslCompiledTransform();
            // set DTD processing to parse.
            using (XmlReader reader =
                XmlReader.Create(new StringReader(xslt),
                new XmlReaderSettings() { DtdProcessing = DtdProcessing.Parse }))
            {
                transform.Load(reader);
            }
            StringWriter results = new StringWriter();
            using (XmlReader reader = XmlReader.Create(new StringReader(inputXml)))
            {
                transform.Transform(reader, null, results);
            }
            return results.ToString();
        }
    }
}
