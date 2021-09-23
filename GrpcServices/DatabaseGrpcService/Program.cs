using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Net;

namespace DatabaseGrpcService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
				.Enrich.FromLogContext()
				.WriteTo.Console()
				.CreateBootstrapLogger();

			try
			{
				Log.Information("Service is starting up..");

				CreateHostBuilder(args).Build().Run();

				Log.Information("Service stopped cleanly");
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "An unhandled exception occurred during bootstrapping!");
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}

		// Additional configuration is required to successfully run gRPC on macOS.
		// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			return Host.CreateDefaultBuilder(args)
				.UseSerilog((context, services, configuration) => configuration
					.WriteTo.Console()
					.ReadFrom.Configuration(context.Configuration)
					.ReadFrom.Services(services))
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>()
					.ConfigureKestrel(options =>
					{
						options.Listen(IPAddress.Any, 5000, listenOptions =>
						{
							
							listenOptions.Protocols = HttpProtocols.Http2;
						});
					});
				});
		}
	}
}
