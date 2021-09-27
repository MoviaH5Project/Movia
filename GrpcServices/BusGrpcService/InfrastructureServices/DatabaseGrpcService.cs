using BusGrpcService.Helpers;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Database = DatabaseGrpcService.Protos;

namespace BusGrpcService.InfrastructureServices
{
	internal interface IDatabaseGrpcService
	{
		Task<Database.Response> CreateBusAsync(Database.Bus bus);
		Task<Database.Response> DeleteBusAsync(Database.Request request);
		Task<Database.BusList> GetAllBussesAsync(Database.Request request);
		Task<Database.Bus> GetBusAsync(Database.Request request);
		Task<Database.Response> UpdateBusAsync(Database.Bus bus);
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

		public async Task<Database.Response> CreateBusAsync(Database.Bus request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.CreateBusAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Bus> GetBusAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.GetBusAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.BusList> GetAllBussesAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.GetAllBussesAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> UpdateBusAsync(Database.Bus request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.UpdateBusAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> DeleteBusAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.DeleteBusAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}
	}
}
