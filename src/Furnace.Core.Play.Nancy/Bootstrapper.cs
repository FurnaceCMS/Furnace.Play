using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Nancy.Validation;
using SimpleInjector;

namespace Furnace.Core.Play.Nancy
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private readonly Container _container;

        public Bootstrapper(Container container)
        {
            _container = container;
        }

        protected override void ApplicationStartup(TinyIoCContainer nancy, IPipelines pipelines)
        {
            // Register Nancy modules.
            foreach (var nancyModule in Modules) _container.Register(nancyModule.ModuleType);

            // Cross-wire Nancy abstractions that application components require (if any). e.g.:
            _container.Register(nancy.Resolve<IModelValidator>);

            // Hook up Simple Injector in the Nancy pipeline.
            nancy.Register(typeof(INancyModuleCatalog), new SimpleInjectorModuleCatalog(_container));
            nancy.Register(typeof(INancyContextFactory), new SimpleInjectorScopedContextFactory(
                _container, nancy.Resolve<INancyContextFactory>()));
        }
    }
}