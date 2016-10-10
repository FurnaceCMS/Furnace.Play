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
            base.ConfigureConventions(conventions);

            conventions.StaticContentsConventions.Add(
             StaticContentConventionBuilder.AddDirectory("assets", @"Content")
         );
        }
    }
}
