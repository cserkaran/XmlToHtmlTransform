namespace Infrastructure.Contracts
{
    /// <summary>
    /// The Queue processor which runs the producer and consumer sequence.
    /// Producer will place messages on this queue and consumer will consume from it whenever 
    /// the message is available.
    /// </summary>
    public interface IMessageQueue
    {
        void Run();
    }
}
