using Furnace.Core.Play.Composition;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Furnace.Core.Play
{
    public class FurnaceStartup
    {
        private readonly IConfigurationRoot _configurationRoot;

        public FurnaceStartup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("furnace.json", false, true)
                .AddJsonFile($"furnace.{env.EnvironmentName}.json", false, true)
                .AddEnvironmentVariables();

            _configurationRoot = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_configurationRoot);
            services.AddSingleton<IFurnaceCompositionRootBuilder, CompositionRootBuilder>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsEnvironment("Developement"))
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseFurnace();
        }
    }
}
