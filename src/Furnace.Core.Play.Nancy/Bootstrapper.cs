using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
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
            // Hook up Simple Injector in the Nancy pipeline.
            nancy.Register(typeof(INancyModuleCatalog), new SimpleInjectorModuleCatalog(_container));
            nancy.Register(typeof(INancyContextFactory), new SimpleInjectorScopedContextFactory(
                _container, nancy.Resolve<INancyContextFactory>()));

            Conventions.ViewLocationConventions.Add((viewName, model, context) => string.Concat("modules/" + context.ModuleName + "/views/", viewName));
        }
    }
}