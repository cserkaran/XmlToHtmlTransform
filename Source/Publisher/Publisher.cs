using System;
using Contracts;
using System.ComponentModel.Composition;
using System.Collections.Generic;

namespace Publisher
{
    [Export(typeof(IPublisher))]
    public class Publisher : IPublisher
    {
        public event EventHandler<XmlContentEventArgs> Published;

        private void OnPublish()
        {
            Published?.Invoke(this, new XmlContentEventArgs(new List<XmlContent>()));
        }

    }
}
