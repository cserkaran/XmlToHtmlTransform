using Infrastructure.CustomEventArgs;
using System;

namespace Infrastructure.Contracts
{
    public interface IProducer
    {
        event EventHandler<XmlContentEventArgs> Produced;

        void Produce();
    }
}
