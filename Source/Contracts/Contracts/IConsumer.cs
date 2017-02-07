namespace Infrastructure.Contracts
{
    public interface IConsumer
    {
        void Consume(XmlContent xmlContent);
    }
}
