using System;
using Furnace.Core.Play.Kernal.Middleware;
using Microsoft.AspNetCore.Builder;
using SimpleInjector.Extensions.ExecutionContextScoping;
using System.Linq;

namespace Furnace.Core.Play
{
    public static class FurnaceApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseFurnace(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            var container = CompositionRootBuilder.Build();
            var furnaceMiddleware = container.GetAllInstances<IFurnaceMiddleware>().OrderBy(mw => mw.Weight);

            return app.UseOwin(pipeline =>
            {
                using (container.BeginExecutionContextScope())
                {
                    foreach (var mw in furnaceMiddleware)
                    {
                        pipeline(next => mw.Invoke);
                    }
                }
            });
        }
    }
}

