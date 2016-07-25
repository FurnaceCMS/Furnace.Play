using System;
using Furnace.Core.Play.Composition;
using Microsoft.AspNetCore.Builder;
using SimpleInjector.Extensions.ExecutionContextScoping;

namespace Furnace.Core.Play
{
    public static class FurnaceApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseFurnace(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            var compositionRootBuilder =
                app.ApplicationServices.GetService(typeof(IFurnaceCompositionRootBuilder)) as IFurnaceCompositionRootBuilder;

            if (compositionRootBuilder == null)
                throw new ArgumentNullException(nameof(compositionRootBuilder));

            compositionRootBuilder.Container.Register(() => compositionRootBuilder);


            var compositionRoot = compositionRootBuilder.Build();

            return app.UseOwin(pipeline =>
            {
                using (compositionRootBuilder.Container.BeginExecutionContextScope())
                {
                    foreach (var mw in compositionRoot.FurnaceMiddleware)
                    {
                        mw.Use(pipeline);
                    }
                }
            });
        }
    }
}

