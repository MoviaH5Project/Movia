using BusGrpcEndpoint.InfrastructureServices;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using BusService = BusGrpcService.Protos;
using TicketService = TicketGrpcService.Protos;

namespace BusGrpcEndpoint
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
				return new TicketService.TicketGrpcService.TicketGrpcServiceClient(
					GrpcChannel.ForAddress(Environment.GetEnvironmentVariable("TICKET_SERVICE_URL"),
					new GrpcChannelOptions
					{
						Credentials = Grpc.Core.ChannelCredentials.Insecure
					}));
			});

			services.AddTransient<IBusGrpcService, InfrastructureServices.BusGrpcService>();
			services.AddTransient<ITicketGrpcService, InfrastructureServices.TicketGrpcService>();

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
				endpoints.MapGrpcService<ApplicationServices.BusGrpcEndpoint>().AllowAnonymous();
			});
		}
	}
}
