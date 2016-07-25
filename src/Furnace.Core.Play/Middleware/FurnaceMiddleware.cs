using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MidFunc = System.Func<System.Func<System.Collections.Generic.IDictionary<string, object>,
            System.Threading.Tasks.Task>, System.Func<System.Collections.Generic.IDictionary<string, object>,
            System.Threading.Tasks.Task>>;

namespace Furnace.Core.Play.Middleware
{
    public abstract class FurnaceMiddleware : IFurnaceMiddleware
    {

        public abstract int Weight { get; }

        public MidFunc Use(Action<MidFunc> builder)
        {
            return next => Next;
        }

        public abstract Task Next(IDictionary<string, object> environment);

    }
}
