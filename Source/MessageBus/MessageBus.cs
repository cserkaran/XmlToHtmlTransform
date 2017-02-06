using Infrastructure.Contracts;
using System.ComponentModel.Composition;

namespace MessageBus
{
    [Export(typeof(IMessageBus))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MessageBus : IMessageBus
    {
        private IPublisher _publisher;
        private ISubscriber _subscriber;

        [ImportingConstructor]
        public MessageBus(IPublisher publisher,ISubscriber subscriber)
        {
            _publisher = publisher;
            _subscriber = subscriber;
        }

        public void Run()
        {
            _publisher.Start();
        }
    }
}
