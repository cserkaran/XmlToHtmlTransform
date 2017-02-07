using Infrastructure.Contracts;
using System;
using System.ComponentModel.Composition;
using System.IO;

namespace Consumer
{
    /// <summary>
    /// The consumer class which consumes the <see cref="XmlContent"/> messages on queue and 
    /// transforms them.
    /// </summary>
    /// <seealso cref="Infrastructure.Contracts.IConsumer" />
    [Export(typeof(IConsumer))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Consumer : IConsumer
    {
        /// <summary>
        /// The output path
        /// </summary>
        private string _outputPath = @"../Output";

        /// <summary>
        /// The XSLT transformation file content.
        /// </summary>
        private string xslt;

        /// <summary>
        /// Initializes a new instance of the <see cref="Consumer"/> class.
        /// </summary>
        public Consumer()
        {
            if (Directory.Exists(_outputPath))
            {
                Directory.Delete(_outputPath, true);
            }

            Directory.CreateDirectory(_outputPath);

            xslt = File.ReadAllText(@"../Resources/Computer.xslt");

            File.WriteAllText(_outputPath + "/Style.css",string.Empty);
            File.Copy(@"../Resources/Style.css", _outputPath + "/Style.css",true);

        }

        /// <summary>
        /// Consumes the specified content.
        /// </summary>
        /// <param name="content">The <see cref="XmlContent"/>.</param>
        public void Consume(XmlContent content)
        {
            var html = Utilities.Utils.TransformXMLToHTML(content.Content, xslt);
            var filePath = string.Format("{0}//{1}.html", _outputPath, content.FileName);
            File.WriteAllText(filePath, html);
            FileInfo info = new FileInfo(filePath);
            Console.WriteLine("Consume content from Queue and write to " + info.FullName);
        }
    }
}
