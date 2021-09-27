using RouteGrpcService.Helpers;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Database = DatabaseGrpcService.Protos;

namespace RouteGrpcService.InfrastructureServices
{
	internal interface IDatabaseGrpcService
	{
		Task<Database.Response> CreateRouteAsync(Database.Route request);
		Task<Database.Response> CreateStopAsync(Database.Stop request);
		Task<Database.Response> DeleteRouteAsync(Database.Request request);
		Task<Database.Response> DeleteStopAsync(Database.Request request);
		Task<Database.RouteList> GetAllRoutesAsync(Database.Request request);
		Task<Database.StopList> GetAllStopsAsync(Database.Request request);
		Task<Database.Route> GetRouteAsync(Database.Request request);
		Task<Database.Stop> GetStopAsync(Database.Request request);
		Task<Database.Response> UpdateRouteAsync(Database.Route request);
		Task<Database.Response> UpdateStopAsync(Database.Stop request);
	}

	internal class DatabaseGrpcService : IDatabaseGrpcService
	{
		private const string _serviceContainerName = "database_service";

		private readonly Database.DatabaseGrpcService.DatabaseGrpcServiceClient _databaseGrpcServiceClient;
		private readonly ILogHelper<DatabaseGrpcService> _logHelper;

		public DatabaseGrpcService(
			Database.DatabaseGrpcService.DatabaseGrpcServiceClient databaseGrpcServiceClient,
			ILogHelper<DatabaseGrpcService> logHelper)
		{
			_databaseGrpcServiceClient = databaseGrpcServiceClient ?? throw new ArgumentNullException(nameof(databaseGrpcServiceClient));
			_logHelper = logHelper ?? throw new ArgumentNullException(nameof(logHelper));
		}

		public async Task<Database.Response> CreateRouteAsync(Database.Route request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.CreateRouteAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Route> GetRouteAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.GetRouteAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.RouteList> GetAllRoutesAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.GetAllRoutesAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> UpdateRouteAsync(Database.Route request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.UpdateRouteAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> DeleteRouteAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.DeleteRouteAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> CreateStopAsync(Database.Stop request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.CreateStopAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Stop> GetStopAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.GetStopAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.StopList> GetAllStopsAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.GetAllStopsAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> UpdateStopAsync(Database.Stop request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.UpdateStopAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> DeleteStopAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.DeleteStopAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}
	}
}
