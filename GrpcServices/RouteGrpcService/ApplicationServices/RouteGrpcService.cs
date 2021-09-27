using Google.Protobuf;
using Grpc.Core;
using RouteGrpcService.Helpers;
using RouteGrpcService.InfrastructureServices;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Database = DatabaseGrpcService.Protos;

namespace RouteGrpcService.ApplicationServices
{
	internal class RouteGrpcService : Protos.RouteGrpcService.RouteGrpcServiceBase
	{
		private const string _serviceContainerName = "route_service";

		private readonly IDatabaseGrpcService _databaseGrpcService;
		private readonly ILogHelper<RouteGrpcService> _logHelper;

		internal RouteGrpcService(IDatabaseGrpcService databaseGrpcService, ILogHelper<RouteGrpcService> logHelper)
		{
			_databaseGrpcService = databaseGrpcService ?? throw new ArgumentNullException(nameof(databaseGrpcService));
			_logHelper = logHelper ?? throw new ArgumentNullException(nameof(logHelper));
		}

		public override async Task<Protos.Response> CreateRoute(Protos.Route request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.CreateRouteAsync(Database.Route.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Route> GetRoute(Protos.Request request, ServerCallContext context)
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
				return Protos.Route.Parser.ParseFrom((await _databaseGrpcService.GetRouteAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.RouteList> GetAllRoutes(Protos.Request request, ServerCallContext context)
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
				return Protos.RouteList.Parser.ParseFrom((await _databaseGrpcService.GetAllRoutesAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> UpdateRoute(Protos.Route request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.UpdateRouteAsync(Database.Route.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> DeleteRoute(Protos.Request request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.DeleteRouteAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> CreateStop(Protos.Stop request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.CreateStopAsync(Database.Stop.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Stop> GetStop(Protos.Request request, ServerCallContext context)
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
				return Protos.Stop.Parser.ParseFrom((await _databaseGrpcService.GetRouteAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.StopList> GetAllStops(Protos.Request request, ServerCallContext context)
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
				return Protos.StopList.Parser.ParseFrom((await _databaseGrpcService.GetAllStopsAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> UpdateStop(Protos.Stop request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.UpdateStopAsync(Database.Stop.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> DeleteStop(Protos.Request request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.DeleteStopAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}
	}
}
