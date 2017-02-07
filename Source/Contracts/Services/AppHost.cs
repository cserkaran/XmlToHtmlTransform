using Infrastructure.Contracts;
using System.ComponentModel.Composition;

namespace Infrastructure.Services
{
    /// <summary>
    /// the app host implementation.
    /// </summary>
    /// <seealso cref="IAppHost" />
    [Export(typeof(IAppHost))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    internal class AppHost : IAppHost
    {
        /// <summary>
        /// Gets the message queue.
        /// </summary>
        /// <value>
        /// The <see cref="IMessageQueue"/>.
        /// </value>
        [Import]
        public IMessageQueue Queue { get; set;}
    }
}
