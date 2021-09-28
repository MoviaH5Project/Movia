using Grpc.Net.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebsiteGrpcEndpoint.InfrastructureServices;
using BusService = BusGrpcService.Protos;
using RouteService = RouteGrpcService.Protos;

namespace WebsiteGrpcEndpoint
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton(services =>
			{
				return new BusService.BusGrpcService.BusGrpcServiceClient(
					GrpcChannel.ForAddress(Environment.GetEnvironmentVariable("BUS_SERVICE_URL"),
					new GrpcChannelOptions
					{
						Credentials = Grpc.Core.ChannelCredentials.Insecure
					}));
			});

			services.AddSingleton(services =>
			{
				return new RouteService.RouteGrpcService.RouteGrpcServiceClient(
					GrpcChannel.ForAddress(Environment.GetEnvironmentVariable("ROUTE_SERVICE_URL"),
					new GrpcChannelOptions
					{
						Credentials = Grpc.Core.ChannelCredentials.Insecure
					}));
			});

			services.AddTransient<IBusGrpcService, InfrastructureServices.BusGrpcService>();
			services.AddTransient<IRouteGrpcService, InfrastructureServices.RouteGrpcService>();

			services.AddCors(opt =>
			{
				opt.AddPolicy("MyPolicy", builder => 
				{
					builder.AllowAnyOrigin();
					builder.AllowAnyMethod();
					builder.AllowAnyHeader();
					builder.WithExposedHeaders("Grpc-Status", "Grpc-Message");
				});
			});

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
			app.UseCors();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGrpcService<ApplicationServices.WebsiteGrpcEndpoint>().AllowAnonymous().RequireCors("MyPolicy").EnableGrpcWeb();
			});
		}
	}
}
