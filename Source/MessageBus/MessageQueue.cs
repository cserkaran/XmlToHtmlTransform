using Infrastructure.Contracts;
using System.ComponentModel.Composition;
using Infrastructure.CustomEventArgs;
using System;
using System.Collections.Concurrent;
using Infrastructure;

namespace MessageBus
{
    [Export(typeof(IMessageQueue))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MessageQueue : IMessageQueue
    {
        private IProducer _publisher;
        private IConsumer _subscriber;
        ProducerConsumer<XmlContent> _producerConsumer;

        [ImportingConstructor]
        public MessageQueue(IProducer publisher,IConsumer subscriber)
        {
            _publisher = publisher;
            _subscriber = subscriber;
            _producerConsumer = new ProducerConsumer<XmlContent>(subscriber.Consume);
        }

        public void Run()
        {
            _publisher.Produced += OnPublished;
            _publisher.Produce();
        }

        private void OnPublished(object sender, XmlContentEventArgs e)
        {
            foreach(var item in e.XmlContents)
            {
                _producerConsumer.Enqueue(item);
            }
        }
    }
}
