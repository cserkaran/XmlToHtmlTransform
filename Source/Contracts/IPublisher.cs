using System;

namespace Contracts
{
    public interface IPublisher
    {
        event EventHandler<XmlContentEventArgs> Published;
    }
}
