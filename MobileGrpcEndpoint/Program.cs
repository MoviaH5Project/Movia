using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MobilEndPointGrpcService
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("Running in debug mode.");
#endif
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// This sections sets the startup configuration.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                     .ConfigureKestrel(options =>
                     {
                         options.Listen(IPAddress.Any, 5200, listenOptions =>
                         {
                             listenOptions.Protocols = HttpProtocols.Http2;
                         });

                     });
                });
    }
}
