using System;
using Infrastructure.Contracts;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using Infrastructure.CustomEventArgs;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Producer
{
    /// <summary>
    /// The producer which read's thru the xml file's and places thier content
    /// on the <see cref="IMessageQueue"/> for consumption by consumers.
    /// </summary>
    /// <seealso cref="Infrastructure.Contracts.IProducer" />
    [Export(typeof(IProducer))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Producer : IProducer
    {
        
        /// <summary>
        /// Occurs when [produced].
        /// </summary>
        public event EventHandler<XmlContentEventArgs> Produced;

        /// <summary>
        /// Produce the messages for queue.
        /// </summary>
        public void Produce()
        {
            Task.Factory.StartNew(() =>
            {
                var dirInfo = new DirectoryInfo(@"../Data/Computers");
                foreach (var file in dirInfo.GetFiles())
                {
                    var fileName = Path.GetFileNameWithoutExtension(file.FullName);
                    var fileContent = File.ReadAllText(file.FullName);
                    XmlContent content = new XmlContent(fileName,fileContent);
                    IList<XmlContent> contents = new List<XmlContent>();
                    contents.Add(content);
                    Console.WriteLine("Produce content from and place it on Queue for " + file.FullName);
                    OnProduced(contents);
                }
            });
           
        }

        /// <summary>
        /// Called when content is produced.
        /// </summary>
        /// <param name="xmlContents">The XML contents.</param>
        private void OnProduced(IList<XmlContent> xmlContents)
        {
            Produced?.Invoke(this, new XmlContentEventArgs(xmlContents));
        }
    }
}
