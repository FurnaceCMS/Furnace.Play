using System.IO;
using Furnace.Core.Play;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<FurnaceStartup>()
                .Build();

            host.Run();
        }
    }
}
