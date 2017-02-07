using Infrastructure.Contracts;
using System;
using System.Collections.Generic;

namespace Infrastructure.CustomEventArgs
{
    /// <summary>
    /// The event args containing payload for the message queue.
    /// Notifies that content has been produced.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class XmlContentEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the XML contents.
        /// </summary>
        /// <value>
        /// The XML contents.
        /// </value>
        public IList<XmlContent> XmlContents { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlContentEventArgs"/> class.
        /// </summary>
        /// <param name="xmlContents">The XML contents.</param>
        public XmlContentEventArgs(IList<XmlContent> xmlContents)
        {
            this.XmlContents = xmlContents;
        }
    }
}
