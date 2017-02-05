using System;
using System.Collections.Generic;

namespace Contracts
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
