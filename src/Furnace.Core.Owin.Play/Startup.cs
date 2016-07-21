using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Furnace.Core.Play;

namespace Furnace.Core.Owin.Play
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
           app.UseFurnace();
        }
    }
}
