namespace Infrastructure.Contracts
{
    /// <summary>
    /// this is the interface of application host..
    /// </summary>
    public interface IAppHost
    {
        /// <summary>
        /// Gets the message bus.
        /// </summary>
        /// <value>
        /// The bus.
        /// </value>
        IMessageQueue Bus { get; }
    }
}
