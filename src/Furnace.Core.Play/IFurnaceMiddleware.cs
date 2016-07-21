using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furnace.Core.Play
{
    public interface IFurnaceMiddleware
    {
        int Weight { get; }
        Task Invoke(IDictionary<string, object> environment);
    }
}