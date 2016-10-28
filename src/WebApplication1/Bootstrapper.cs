using Nancy;
using Nancy.Configuration;
using Nancy.Conventions;
using SimpleInjector;

namespace WebApplication1
{
    public class Bootstrapper: Furnace.Core.Nancy.Play.Bootstrapper
    {
        public Bootstrapper(Container container) : base(container)
        {
        }

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("bower_components", @"Content/bower_components"));
            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("src", @"Content/bower_components/furnace-app/src"));
            base.ConfigureConventions(conventions);
        }

        public override void Configure(INancyEnvironment environment)
        {
            environment.Tracing(enabled: false, displayErrorTraces: true);
            base.Configure(environment);
        }
    }
}
