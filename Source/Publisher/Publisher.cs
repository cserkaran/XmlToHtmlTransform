using System;
using Infrastructure.Contracts;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using Infrastructure.CustomEventArgs;
using System.IO;

namespace Publisher
{
    [Export(typeof(IPublisher))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Publisher : IPublisher
    {
        public event EventHandler<XmlContentEventArgs> Published;

        private void OnPublish(IList<XmlContent> xmlContents)
        {
            Published?.Invoke(this, new XmlContentEventArgs(xmlContents));
        }

        public void Start()
        {
            var dirInfo = new DirectoryInfo(@"../Data/Computers");

            foreach (var file in dirInfo.GetFiles())
            {
                XmlContent content = new XmlContent(file.Name,File.ReadAllText(file.FullName));
                IList<XmlContent> contents = new List<XmlContent>();
                contents.Add(content);
                OnPublish(contents);
            }

        }

    }
}
