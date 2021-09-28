using System;
using System.Reflection;
using System.Threading.Tasks;
using WebsiteGrpcEndpoint.Helpers;
using RouteService = RouteGrpcService.Protos;

namespace WebsiteGrpcEndpoint.InfrastructureServices
{
	public interface IRouteGrpcService
	{
		Task<RouteService.Response> CreateRouteAsync(RouteService.Route request);
		Task<RouteService.Response> CreateStopAsync(RouteService.Stop request);
		Task<RouteService.Response> DeleteRouteAsync(RouteService.Request request);
		Task<RouteService.Response> DeleteStopAsync(RouteService.Request request);
		Task<RouteService.RouteList> GetAllRoutesAsync(RouteService.Request request);
		Task<RouteService.StopList> GetAllStopsAsync(RouteService.Request request);
		Task<RouteService.Route> GetRouteAsync(RouteService.Request request);
		Task<RouteService.Stop> GetStopAsync(RouteService.Request request);
		Task<RouteService.Response> UpdateRouteAsync(RouteService.Route request);
		Task<RouteService.Response> UpdateStopAsync(RouteService.Stop request);
	}

	public class RouteGrpcService : IRouteGrpcService
	{
		private const string _serviceContainerName = "route_service";

		private readonly RouteService.RouteGrpcService.RouteGrpcServiceClient _routeGrpcServiceClient;
		private readonly ILogHelper<RouteGrpcService> _logHelper;

		public RouteGrpcService(RouteService.RouteGrpcService.RouteGrpcServiceClient routeGrpcServiceClient, ILogHelper<RouteGrpcService> logHelper)
		{
			_routeGrpcServiceClient = routeGrpcServiceClient ?? throw new ArgumentNullException(nameof(routeGrpcServiceClient));
			_logHelper = logHelper ?? throw new ArgumentNullException(nameof(logHelper));
		}

		public async Task<RouteService.Response> CreateRouteAsync(RouteService.Route request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _routeGrpcServiceClient.CreateRouteAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<RouteService.Route> GetRouteAsync(RouteService.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _routeGrpcServiceClient.GetRouteAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<RouteService.RouteList> GetAllRoutesAsync(RouteService.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _routeGrpcServiceClient.GetAllRoutesAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<RouteService.Response> UpdateRouteAsync(RouteService.Route request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _routeGrpcServiceClient.UpdateRouteAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<RouteService.Response> DeleteRouteAsync(RouteService.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _routeGrpcServiceClient.DeleteRouteAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<RouteService.Response> CreateStopAsync(RouteService.Stop request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _routeGrpcServiceClient.CreateStopAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<RouteService.Stop> GetStopAsync(RouteService.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _routeGrpcServiceClient.GetStopAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<RouteService.StopList> GetAllStopsAsync(RouteService.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _routeGrpcServiceClient.GetAllStopsAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<RouteService.Response> UpdateStopAsync(RouteService.Stop request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _routeGrpcServiceClient.UpdateStopAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<RouteService.Response> DeleteStopAsync(RouteService.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _routeGrpcServiceClient.DeleteStopAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}
	}
}
