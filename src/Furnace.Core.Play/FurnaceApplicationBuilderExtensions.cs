using System;
using Furnace.Core.Play.Composition;
using Furnace.Core.Play.Query;
using Furnace.Core.Play.Query.ConfigurationRoot;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using SimpleInjector.Extensions.ExecutionContextScoping;

namespace Furnace.Core.Play
{
    public static class FurnaceApplicationBuilderExtensions
    {
        public static void UseFurnace(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            var compositionRootBuilder =
                app.ApplicationServices.GetService(typeof(IFurnaceCompositionRootBuilder)) as IFurnaceCompositionRootBuilder;

            if (compositionRootBuilder == null)
                throw new ArgumentNullException(nameof(compositionRootBuilder));


            var configurationRoot =
                app.ApplicationServices.GetService(typeof(IConfigurationRoot)) as IConfigurationRoot;

            compositionRootBuilder.Container.Register(() => configurationRoot);
            compositionRootBuilder.Container.Register(() => compositionRootBuilder);

            compositionRootBuilder.Container.Register<IQueryHandler<ConfigurationRootQuery, ConfigurationRootQueryResult>, ConfigurationRootQueryHandler>();



           var compositionRoot = compositionRootBuilder.Build();

            foreach (var mw in compositionRoot.FurnaceMiddleware)
            {
                using (compositionRootBuilder.Container.BeginExecutionContextScope())
                {
                    app.UseOwin(pipeline => pipeline(next => mw.Invoke));
                }
            }
        }
    }
}

