using System;
using Furnace.Core.Play.Middleware;
using Nancy.Owin;

using MidFunc = System.Func<System.Func<System.Collections.Generic.IDictionary<string, object>,
            System.Threading.Tasks.Task>, System.Func<System.Collections.Generic.IDictionary<string, object>,
            System.Threading.Tasks.Task>>;

namespace Furnace.Core.Play.Nancy
{
    public class NancyMiddlewareFacade: IFurnaceMiddleware
    {
        private readonly NancyOptions _options;

        public NancyMiddlewareFacade(NancyOptions options)
        {
            _options = options;
        }

        public int Weight => -1;
        public MidFunc Use(Action<MidFunc> builder)
        {
            return NancyMiddleware.UseNancy(_options);
        }
    }
}
