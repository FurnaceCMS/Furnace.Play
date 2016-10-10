using Nancy.Conventions;
using SimpleInjector;

namespace WebApplication1
{
    public class Bootstrapper: Furnace.Core.Nancy.Play.Bootstrapper
    {
        public Bootstrapper(Container container) : base(container)
        {
            var t = true;
        }

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("bower_components", @"Content/bower_components"));
            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("src", @"Content/bower_components/furnace-app/src"));
            base.ConfigureConventions(conventions);
        }
    }
}
