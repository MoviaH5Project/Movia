using Google.Protobuf;
using Grpc.Core;
using System;
using System.Reflection;
using System.Threading.Tasks;
using WebsiteGrpcEndpoint.Helpers;
using WebsiteGrpcEndpoint.InfrastructureServices;
using BusService = BusGrpcService.Protos;
using RouteService = RouteGrpcService.Protos;
using WebsiteEndpoint = WebsiteGrpcEndpoint.Protos;

namespace WebsiteGrpcEndpoint.ApplicationServices
{
	public class WebsiteGrpcEndpoint : WebsiteEndpoint.WebsiteGrpcEndpoint.WebsiteGrpcEndpointBase
	{
		private const string _serviceContainerName = "bus_service";

		private readonly IBusGrpcService _busGrpcService;
		private readonly IRouteGrpcService _routeGrpcService;
		private readonly ILogHelper<WebsiteGrpcEndpoint> _logHelper;

		public WebsiteGrpcEndpoint(IBusGrpcService busGrpcService, IRouteGrpcService routeGrpcService, ILogHelper<WebsiteGrpcEndpoint> logHelper)
		{
			_busGrpcService = busGrpcService ?? throw new ArgumentNullException(nameof(busGrpcService));
			_routeGrpcService = routeGrpcService ?? throw new ArgumentNullException(nameof(routeGrpcService));
			_logHelper = logHelper ?? throw new ArgumentNullException(nameof(logHelper));
		}

		public override async Task<WebsiteEndpoint.Response> CreateBus(WebsiteEndpoint.Bus request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.Response.Parser.ParseFrom((await _busGrpcService.CreateBusAsync(BusService.Bus.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<WebsiteEndpoint.Bus> GetBus(WebsiteEndpoint.Request request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.Bus.Parser.ParseFrom((await _busGrpcService.GetBusAsync(BusService.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<WebsiteEndpoint.BusList> GetAllBusses(WebsiteEndpoint.Request request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.BusList.Parser.ParseFrom((await _busGrpcService.GetAllBussesAsync(BusService.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<WebsiteEndpoint.Response> UpdateBus(WebsiteEndpoint.Bus request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.Response.Parser.ParseFrom((await _busGrpcService.UpdateBusAsync(BusService.Bus.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<WebsiteEndpoint.Response> DeleteBus(WebsiteEndpoint.Request request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.Response.Parser.ParseFrom((await _busGrpcService.DeleteBusAsync(BusService.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<WebsiteEndpoint.Response> CreateRoute(WebsiteEndpoint.Route request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.Response.Parser.ParseFrom((await _routeGrpcService.CreateRouteAsync(RouteService.Route.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<WebsiteEndpoint.Route> GetRoute(WebsiteEndpoint.Request request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.Route.Parser.ParseFrom((await _routeGrpcService.GetRouteAsync(RouteService.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<WebsiteEndpoint.RouteList> GetAllRoutes(WebsiteEndpoint.Request request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.RouteList.Parser.ParseFrom((await _routeGrpcService.GetAllRoutesAsync(RouteService.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<WebsiteEndpoint.Response> UpdateRoute(WebsiteEndpoint.Route request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.Response.Parser.ParseFrom((await _routeGrpcService.UpdateRouteAsync(RouteService.Route.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<WebsiteEndpoint.Response> DeleteRoute(WebsiteEndpoint.Request request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.Response.Parser.ParseFrom((await _routeGrpcService.DeleteRouteAsync(RouteService.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<WebsiteEndpoint.Response> CreateStop(WebsiteEndpoint.Stop request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.Response.Parser.ParseFrom((await _routeGrpcService.CreateStopAsync(RouteService.Stop.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<WebsiteEndpoint.Stop> GetStop(WebsiteEndpoint.Request request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.Stop.Parser.ParseFrom((await _routeGrpcService.GetStopAsync(RouteService.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<WebsiteEndpoint.StopList> GetAllStops(WebsiteEndpoint.Request request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.StopList.Parser.ParseFrom((await _routeGrpcService.GetAllStopsAsync(RouteService.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<WebsiteEndpoint.Response> UpdateStop(WebsiteEndpoint.Stop request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.Response.Parser.ParseFrom((await _routeGrpcService.UpdateStopAsync(RouteService.Stop.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<WebsiteEndpoint.Response> DeleteStop(WebsiteEndpoint.Request request, ServerCallContext context)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				_logHelper.LogNullException(nameof(context));
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return WebsiteEndpoint.Response.Parser.ParseFrom((await _routeGrpcService.DeleteStopAsync(RouteService.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}
	}
}
