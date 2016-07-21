using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using SimpleInjector;
using System.Linq;
using System.Reflection;
using Furnace.Core.Play;
using Furnace.Core.Play.GraphTheory.Algorithms;
using Furnace.Core.Play.GraphTheory.Graphs;
using SimpleInjector.Extensions.ExecutionContextScoping;

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
