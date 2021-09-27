using BusGrpcService.Helpers;
using BusGrpcService.InfrastructureServices;
using Google.Protobuf;
using Grpc.Core;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Database = DatabaseGrpcService.Protos;

namespace BusGrpcService.ApplicationServices
{
	internal class BusGrpcService : Protos.BusGrpcService.BusGrpcServiceBase
	{
		private const string _serviceContainerName = "bus_service";

		private readonly IDatabaseGrpcService _databaseGrpcService;
		private readonly ILogHelper<BusGrpcService> _logHelper;

		public BusGrpcService(IDatabaseGrpcService databaseGrpcService, ILogHelper<BusGrpcService> logHelper)
		{
			_databaseGrpcService = databaseGrpcService;
			_logHelper = logHelper ?? throw new ArgumentNullException(nameof(logHelper));
		}

		public override async Task<Protos.Response> CreateBus(Protos.Bus request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.CreateBusAsync(Database.Bus.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Bus> GetBus(Protos.Request request, ServerCallContext context)
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
				return Protos.Bus.Parser.ParseFrom((await _databaseGrpcService.GetBusAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.BusList> GetAllBusses(Protos.Request request, ServerCallContext context)
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
				return Protos.BusList.Parser.ParseFrom((await _databaseGrpcService.GetAllBussesAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> UpdateBus(Protos.Bus request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.UpdateBusAsync(Database.Bus.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> DeleteBus(Protos.Request request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.DeleteBusAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}
	}
}
