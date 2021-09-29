using BusGrpcEndpoint.Helpers;
using System;
using System.Reflection;
using System.Threading.Tasks;
using TicketService = TicketGrpcService.Protos;

namespace BusGrpcEndpoint.InfrastructureServices
{
	public interface ITicketGrpcService
	{
		Task<TicketService.Fob> GetFobByNfcAsync(TicketService.Nfc request);
	}

	public class TicketGrpcService : ITicketGrpcService
	{
		private const string _serviceContainerName = "ticket_service";

		private readonly TicketService.TicketGrpcService.TicketGrpcServiceClient _ticketGrpcServiceClient;
		private readonly ILogHelper<TicketGrpcService> _logHelper;

		public TicketGrpcService(TicketService.TicketGrpcService.TicketGrpcServiceClient ticketGrpcServiceClient, ILogHelper<TicketGrpcService> logHelper)
		{
			_ticketGrpcServiceClient = ticketGrpcServiceClient;
			_logHelper = logHelper;
		}

		public async Task<TicketService.Fob> GetFobByNfcAsync(TicketService.Nfc request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _ticketGrpcServiceClient.GetFobByNfcAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}
	}
}
