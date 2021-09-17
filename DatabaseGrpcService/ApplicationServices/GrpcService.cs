using DatabaseGrpcService.DomainServices;
using DatabaseGrpcService.InfrastructureServices.Repository;
using DatabaseGrpcService.Models;
using DatabaseGrpcService.Protos;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DatabaseGrpcService.ApplicationServices
{
	internal class GrpcService : Protos.DatabaseGrpcService.DatabaseGrpcServiceBase
	{
		private readonly IMapperService _mapperService;
		private readonly IBusRepository _busRepository;
		private readonly IRouteRepository _routeRepository;
		private readonly IStopRepository _stopRepository;
		private readonly ITicketRepository _ticketRepository;
		private readonly IPassengerRepository _passengerRepository;
		private readonly IFobRepository _fobRepository;
		private readonly INfcRepository _nfcRepository;
		private readonly ILogger<GrpcService> _logger;

		public GrpcService(
			IMapperService mapperService,
			IBusRepository busRepository,
			IRouteRepository routeRepository,
			IStopRepository stopRepository,
			ITicketRepository ticketRepository,
			IPassengerRepository passengerRepository,
			IFobRepository fobRepository,
			INfcRepository nfcRepository,
			ILogger<GrpcService> logger)
		{
			_mapperService = mapperService;
			_busRepository = busRepository;
			_routeRepository = routeRepository;
			_stopRepository = stopRepository;
			_ticketRepository = ticketRepository;
			_passengerRepository = passengerRepository;
			_fobRepository = fobRepository;
			_nfcRepository = nfcRepository;
			_logger = logger;
		}

		public override async Task<Response> CreateBus(Bus request, ServerCallContext context)
		{
			try
			{
				_ = await _busRepository.InsertAsync(_mapperService.MapFromProtoToDao<Bus, BusDao>(request));
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		public override async Task<Response> CreateRoute(Route request, ServerCallContext context)
		{
			try
			{
				_ = await _routeRepository.InsertAsync(_mapperService.MapFromProtoToDao<Route, RouteDao>(request));
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}
	}
}
