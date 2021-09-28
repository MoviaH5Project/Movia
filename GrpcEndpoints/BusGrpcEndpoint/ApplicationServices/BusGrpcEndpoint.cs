using BusGrpcEndpoint.Helpers;
using BusGrpcEndpoint.InfrastructureServices;
using Google.Protobuf;
using Grpc.Core;
using System;
using System.Reflection;
using System.Threading.Tasks;
using BusEndpoint = BusGrpcEndpoint.Protos;
using BusService = BusGrpcService.Protos;
using TicketService = TicketGrpcService.Protos;

namespace BusGrpcEndpoint.ApplicationServices
{
	public class BusGrpcEndpoint : BusEndpoint.BusGrpcEndpoint.BusGrpcEndpointBase
	{
		private const string _serviceContainerName = "bus_service";

		private readonly IBusGrpcService _busGrpcService;
		private readonly ITicketGrpcService _ticketGrpcService;
		private readonly ILogHelper<BusGrpcEndpoint> _logHelper;

		public BusGrpcEndpoint(IBusGrpcService busGrpcService, ITicketGrpcService ticketGrpcService, ILogHelper<BusGrpcEndpoint> logHelper)
		{
			_busGrpcService = busGrpcService ?? throw new ArgumentNullException(nameof(busGrpcService));
			_ticketGrpcService = ticketGrpcService ?? throw new ArgumentNullException(nameof(ticketGrpcService));
			_logHelper = logHelper ?? throw new ArgumentNullException(nameof(logHelper));
		}

		public override async Task<BusEndpoint.Bus> GetBus(BusEndpoint.BusRequest request, ServerCallContext context)
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
				return BusEndpoint.Bus.Parser.ParseFrom((await _busGrpcService.GetBusAsync(BusService.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<BusEndpoint.Fob> GetFob(BusEndpoint.Nfc request, ServerCallContext context)
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
				return BusEndpoint.Fob.Parser.ParseFrom((await _ticketGrpcService.GetFobByNfcAsync(TicketService.Nfc.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<BusEndpoint.Response> CheckIn(BusEndpoint.Nfc request, ServerCallContext context)
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
				return BusEndpoint.Response.Parser.ParseFrom((await _ticketGrpcService.CheckInAsync(TicketService.Nfc.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<BusEndpoint.Response> CheckOut(BusEndpoint.Fob request, ServerCallContext context)
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
				return BusEndpoint.Response.Parser.ParseFrom((await _ticketGrpcService.CheckOutAsync(TicketService.Fob.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}
	}
}
