using System;
using System.Reflection;
using System.Threading.Tasks;
using WebsiteGrpcEndpoint.Helpers;
using BusService = BusGrpcService.Protos;

namespace WebsiteGrpcEndpoint.InfrastructureServices
{
	public interface IBusGrpcService
	{
		Task<BusService.Response> CreateBusAsync(BusService.Bus request);
		Task<BusService.Response> DeleteBusAsync(BusService.Request request);
		Task<BusService.BusList> GetAllBussesAsync(BusService.Request request);
		Task<BusService.Bus> GetBusAsync(BusService.Request request);
		Task<BusService.Response> UpdateBusAsync(BusService.Bus request);
	}

	public class BusGrpcService : IBusGrpcService
	{
		private const string _serviceContainerName = "bus_service";

		private readonly BusService.BusGrpcService.BusGrpcServiceClient _busGrpcServiceClient;
		private readonly ILogHelper<BusGrpcService> _logHelper;

		public BusGrpcService(BusService.BusGrpcService.BusGrpcServiceClient busGrpcServiceClient, ILogHelper<BusGrpcService> logHelper)
		{
			_busGrpcServiceClient = busGrpcServiceClient ?? throw new ArgumentNullException(nameof(busGrpcServiceClient));
			_logHelper = logHelper ?? throw new ArgumentNullException(nameof(logHelper));
		}

		public async Task<BusService.Response> CreateBusAsync(BusService.Bus request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _busGrpcServiceClient.CreateBusAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<BusService.Bus> GetBusAsync(BusService.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _busGrpcServiceClient.GetBusAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<BusService.BusList> GetAllBussesAsync(BusService.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _busGrpcServiceClient.GetAllBussesAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<BusService.Response> UpdateBusAsync(BusService.Bus request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _busGrpcServiceClient.UpdateBusAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<BusService.Response> DeleteBusAsync(BusService.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _busGrpcServiceClient.DeleteBusAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}
	}
}
