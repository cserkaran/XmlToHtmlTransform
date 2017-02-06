using Infrastructure.CustomEventArgs;
using System;

namespace Infrastructure.Contracts
{
    public interface IPublisher
    {
        event EventHandler<XmlContentEventArgs> Published;

        void Start();
    }
}
