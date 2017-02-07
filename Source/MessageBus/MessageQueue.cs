using Infrastructure.Contracts;
using System.ComponentModel.Composition;
using Infrastructure.CustomEventArgs;
using System;
using System.Collections.Concurrent;
using Infrastructure;

namespace MessageQueue
{
    /// <summary>
    /// The Queue processor which runs the producer and consumer sequence.
    /// Producer will place messages on this queue and consumer will consume from it whenever 
    /// the message is available.
    /// </summary>
    /// <seealso cref="Infrastructure.Contracts.IMessageQueue" />
    [Export(typeof(IMessageQueue))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MessageQueue : IMessageQueue
    {
        /// <summary>
        /// The producer
        /// </summary>
        private IProducer _producer;

        /// <summary>
        /// The consumer
        /// </summary>
        private IConsumer _consumer;

        /// <summary>
        /// The producer consumer queue.
        /// </summary>
        ProducerConsumer<XmlContent> _producerConsumer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageQueue"/> class.
        /// </summary>
        /// <param name="producer">The producer.</param>
        /// <param name="consumer">The consumer.</param>
        [ImportingConstructor]
        public MessageQueue(IProducer producer,IConsumer consumer)
        {
            _producer = producer;
            _consumer = consumer;
            _producerConsumer = new ProducerConsumer<XmlContent>(consumer.Consume);
        }

        /// <summary>
        /// Runs the queue.
        /// </summary>
        public void Run()
        {
            _producer.Produced += OnProduced;
            _producer.Produce();
        }

        /// <summary>
        /// Called when producer has produced the content.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="XmlContentEventArgs"/> instance containing the event data.</param>
        private void OnProduced(object sender, XmlContentEventArgs e)
        {
            foreach(var item in e.XmlContents)
            {
                _producerConsumer.Enqueue(item);
            }
        }
    }
}
