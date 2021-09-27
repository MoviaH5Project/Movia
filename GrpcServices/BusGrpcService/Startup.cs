using BusGrpcService.Helpers;
using BusGrpcService.InfrastructureServices;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Database = DatabaseGrpcService.Protos;

namespace BusGrpcService
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<Database.DatabaseGrpcService.DatabaseGrpcServiceClient>(services =>
			{
				return new Database.DatabaseGrpcService.DatabaseGrpcServiceClient(
					GrpcChannel.ForAddress(Environment.GetEnvironmentVariable("DATABASE_SERVICE_URL"),
					new GrpcChannelOptions
					{
						Credentials = Grpc.Core.ChannelCredentials.Insecure
					}));
			});
			services.AddTransient<IDatabaseGrpcService, InfrastructureServices.DatabaseGrpcService>();
			services.AddTransient(typeof(ILogHelper<>), typeof(LogHelper<>));

			services.AddGrpc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGrpcService<ApplicationServices.BusGrpcService>();
			});
		}
	}
}
