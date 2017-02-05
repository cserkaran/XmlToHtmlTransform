using System;
using Contracts;

namespace Publisher
{
    public class Publisher : IPublisher
    {
        public event EventHandler<XmlContentEventArgs> Published;
    }
}
