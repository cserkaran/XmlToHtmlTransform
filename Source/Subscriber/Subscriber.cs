using System;
using System.Collections.Generic;
using Contracts;
using System.ComponentModel.Composition;

namespace Subscriber
{
    [Export(typeof(ISubscriber))]
    public class Subscriber : ISubscriber
    {
        public void Notify(IList<XmlContent> xmlContents)
        {
            throw new NotImplementedException();
        }
    }
}
