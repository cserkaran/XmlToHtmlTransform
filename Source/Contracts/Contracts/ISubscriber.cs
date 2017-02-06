using System.Collections.Generic;

namespace Infrastructure.Contracts
{
    public interface ISubscriber
    {
        void Notify(IList<XmlContent> xmlContents);
    }
}
