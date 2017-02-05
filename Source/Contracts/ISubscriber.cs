using System.Collections.Generic;

namespace Contracts
{
    public interface ISubscriber
    {
        void Notify(IList<XmlContent> xmlContents);
    }
}
