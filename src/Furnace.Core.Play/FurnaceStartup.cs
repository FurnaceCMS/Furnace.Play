using Furnace.Core.Play.Composition;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Furnace.Core.Play
{
    public class FurnaceStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFurnaceCompositionRootBuilder, CompositionRootBuilder>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseFurnace();
        }
    }
}
