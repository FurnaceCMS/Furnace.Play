using System;
using System.Collections.Generic;
using Furnace.Core.Play;
using Microsoft.AspNetCore.Builder;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using System.Linq;

namespace Furnace.Core.Owin.Play
{
    public static class FurnaceApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseFurnace(this IApplicationBuilder app, Container container)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            var furnaceMiddleware = container.GetAllInstances<IFurnaceMiddleware>();

            var furnaceMiddlewares = furnaceMiddleware as IList<IFurnaceMiddleware> ?? furnaceMiddleware.ToList();

            return app.UseOwin(pipeline =>
            {
                using (container.BeginExecutionContextScope())
                {
                    foreach (var middleware in furnaceMiddlewares.OrderBy(mw => mw.Weight))
                    {
                        pipeline(next => middleware.Invoke);
                    }
                }
            });
        }
    }
}

