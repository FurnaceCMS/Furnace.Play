using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furnace.Core.Play.Kernal.Middleware
{
    public interface IFurnaceMiddleware
    {
        int Weight { get; }
        Task Invoke(IDictionary<string, object> environment);
    }
}