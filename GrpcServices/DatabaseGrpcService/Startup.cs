using DatabaseGrpcService.ApplicationServices;
using DatabaseGrpcService.DomainServices;
using DatabaseGrpcService.InfrastructureServices.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System;
using System.Data;

namespace DatabaseGrpcService
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			if (services is null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			// Infrastructure services
			services.AddTransient<IDbConnection>(services =>
			{
				return new NpgsqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
			});

			services.AddTransient<IBusRepository, BusRepository>();
			services.AddTransient<IStopRepository, StopRepository>();
			services.AddTransient<IRouteRepository, RouteRepository>();
			services.AddTransient<ITicketRepository, TicketRepository>();
			services.AddTransient<IPassengerRepository, PassengerRepository>();
			services.AddTransient<IRouteStopsRepository, RouteStopsRepository>();
			services.AddTransient<IFobRepository, FobRepository>();
			services.AddTransient<INfcRepository, NfcRepository>();

			// Domain Services
			services.AddSingleton<IMapperService, MapperService>();

			// Application Services

			services.AddAutoMapper(typeof(AutoMapperProfile));
			services.AddGrpc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (app is null)
			{
				throw new ArgumentNullException(nameof(app));
			}

			if (env is null)
			{
				throw new ArgumentNullException(nameof(env));
			}

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGrpcService<GrpcService>();

				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
				});
			});
		}
	}
}
