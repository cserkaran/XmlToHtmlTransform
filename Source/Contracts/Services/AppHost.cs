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
        [Import]
        public IMessageQueue Bus { get; set;}
    }
}
