using System;
using MidFunc = System.Func<System.Func<System.Collections.Generic.IDictionary<string, object>,
            System.Threading.Tasks.Task>, System.Func<System.Collections.Generic.IDictionary<string, object>,
            System.Threading.Tasks.Task>>;

namespace Furnace.Core.Play.Middleware
{
    public interface IFurnaceMiddleware
    {
        int Weight { get; }
        MidFunc Use(Action<MidFunc> builder);
    }
}