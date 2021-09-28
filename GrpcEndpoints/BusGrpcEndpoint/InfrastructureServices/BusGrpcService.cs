using BusGrpcEndpoint.Helpers;
using System;
using System.Reflection;
using System.Threading.Tasks;
using BusService = BusGrpcService.Protos;

namespace BusGrpcEndpoint.InfrastructureServices
{
	public interface IBusGrpcService
	{
		Task<BusService.Bus> GetBusAsync(BusService.Request request);
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
	}
}
