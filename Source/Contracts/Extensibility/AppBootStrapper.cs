using Infrastructure.Contracts;
using Infrastructure.Services;
using Prism.Mef;
using System.ComponentModel.Composition.Hosting;

namespace Infrastructure.Extensibility
{
    /// <summary>
    /// The application bootstrapper. Load the dependencies and component implementations via MEF.
    /// It will satisfy the Import attributes with the implementations exported via Export attributes.
    /// </summary>
    /// <seealso cref="Prism.Mef.MefBootstrapper" />
    public sealed class AppBootStrapper : MefBootstrapper
    {
        /// <summary>
        /// Configures the <see cref="P:Prism.Mef.MefBootstrapper.AggregateCatalog" /> used by MEF.
        /// </summary>
        /// <remarks>
        /// The base implementation does nothing.
        /// </remarks>
        protected override void ConfigureAggregateCatalog()
        {
            var buildDirectoryCatalog = new DirectoryCatalog(@"../Build");
            AggregateCatalog.Catalogs.Add(buildDirectoryCatalog);
            base.ConfigureAggregateCatalog();
        }

        /// <summary>
        /// Configures the <see cref="T:System.ComponentModel.Composition.Hosting.CompositionContainer" />.
        /// May be overwritten in a derived class to add specific type mappings required by the application.
        /// </summary>
        /// <remarks>
        /// The base implementation registers all the types direct instantiated by the bootstrapper with the container.
        /// If the method is overwritten, the new implementation should call the base class version.
        /// </remarks>
        protected override void ConfigureContainer()
        {
            AppContext.Instance.Initialize(this.Container.GetExportedValue<IAppHost>());
            base.ConfigureContainer();
        }
    }
}
