using Infrastructure.Contracts;

namespace Infrastructure.Services
{
    /// <summary>
    /// This context class can expose all the platform services for application like
    /// exception handling, logging to name a few.
    /// </summary>
    public class AppContext : SingletonBase<AppContext>
    {
        #region Properties 

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public IAppHost Host { get; private set; }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes the specified host.
        /// </summary>
        /// <param name="host">The host.</param>
        public void Initialize(IAppHost host)
        {
            Host = host;
        }

        #endregion
    }
}
