using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Furnace.Core.Play;
using Furnace.Core.Play.Kernal.Composition;

namespace Furnace.Core.Owin.Play
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFurnaceCompositionRootBuilder, FurnaceCompositionRootBuilder>();
        }

        public void Configure(IApplicationBuilder app)
        {
           app.UseFurnace();
        }
    }
}
