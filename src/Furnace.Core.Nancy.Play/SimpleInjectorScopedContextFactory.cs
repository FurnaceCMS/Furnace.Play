using Nancy;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;

namespace Furnace.Core.Nancy.Play
{
    public class SimpleInjectorScopedContextFactory: INancyContextFactory
    {
        private readonly Container _container;
        private readonly INancyContextFactory _defaultFactory;

        public SimpleInjectorScopedContextFactory(Container container, INancyContextFactory @default)
        {
            _container = container;
            _defaultFactory = @default;
        }

        public NancyContext Create(Request request)
        {
            var context = _defaultFactory.Create(request);
            context.Items.Add("SimpleInjector.Scope", _container.BeginExecutionContextScope());
            return context;
        }
    }
}
