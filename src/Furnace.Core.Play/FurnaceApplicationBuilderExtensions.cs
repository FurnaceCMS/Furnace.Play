using System;
using System.Security.Cryptography.X509Certificates;
using Furnace.Core.Play.Composition;
using Microsoft.AspNetCore.Builder;
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

            compositionRootBuilder.Container.Register(() => compositionRootBuilder);

            var compositionRoot = compositionRootBuilder.Build();

            foreach (var mw in compositionRoot.FurnaceMiddleware)
            {
                using (compositionRootBuilder.Container.BeginExecutionContextScope())
                {
                    app.UseOwin(pipeline =>
                    {
                        pipeline(next => mw.Invoke);
                    });
                    
                }
            }

        }
    }
}

