using System;
using Infrastructure.Contracts;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using Infrastructure.CustomEventArgs;

namespace Publisher
{
    [Export(typeof(IPublisher))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Publisher : IPublisher
    {
        public event EventHandler<XmlContentEventArgs> Published;

        private void OnPublish()
        {
            Published?.Invoke(this, new XmlContentEventArgs(new List<XmlContent>()));
        }

    }
}
