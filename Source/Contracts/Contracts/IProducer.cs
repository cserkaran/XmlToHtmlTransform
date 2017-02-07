using Infrastructure.CustomEventArgs;
using System;

namespace Infrastructure.Contracts
{
    /// <summary>
    /// The producer which read's thru the xml file's and places thier content
    /// on the <see cref="IMessageQueue"/> for consumption by consumers.
    /// </summary>
    public interface IProducer
    {
        /// <summary>
        /// Occurs when message is produced for the queue.
        /// </summary>
        event EventHandler<XmlContentEventArgs> Produced;

        /// <summary>
        /// Produce the content for the queue.
        /// </summary>
        void Produce();
    }
}
