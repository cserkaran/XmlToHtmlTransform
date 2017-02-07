namespace Infrastructure.Contracts
{
    /// <summary>
    /// The consumer interface to consume the <see cref="XmlContent"/>
    /// </summary>
    public interface IConsumer
    {
        /// <summary>
        /// Consumes the specified XML content.
        /// </summary>
        /// <param name="xmlContent">Content of the XML.</param>
        void Consume(XmlContent xmlContent);
    }
}
