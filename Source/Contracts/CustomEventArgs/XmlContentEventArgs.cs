using Infrastructure.Contracts;
using System;
using System.Collections.Generic;

namespace Infrastructure.CustomEventArgs
{
    public class XmlContentEventArgs : EventArgs
    {
        public IList<XmlContent> XmlContents { get; }

        public XmlContentEventArgs(IList<XmlContent> xmlContents)
        {
            this.XmlContents = xmlContents;
        }
    }
}
