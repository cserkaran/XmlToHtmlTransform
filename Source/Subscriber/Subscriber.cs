using System;
using System.Collections.Generic;
using Infrastructure.Contracts;
using System.ComponentModel.Composition;

namespace Subscriber
{
    [Export(typeof(ISubscriber))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Subscriber : ISubscriber
    {
        public void Notify(IList<XmlContent> xmlContents)
        {
            
        }
    }
}
