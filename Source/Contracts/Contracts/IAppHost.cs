namespace Infrastructure.Contracts
{
    /// <summary>
    /// Gets the message queue.
    /// </summary>
    /// <value>
    /// The <see cref="IMessageQueue"/>.
    /// </value>
    public interface IAppHost
    {
        /// <summary>
        /// Gets the message bus.
        /// </summary>
        /// <value>
        /// The bus.
        /// </value>
        IMessageQueue Queue { get; }
    }
}
