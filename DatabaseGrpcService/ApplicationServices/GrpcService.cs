using DatabaseGrpcService.DomainServices;
using DatabaseGrpcService.InfrastructureServices.Repository;
using DatabaseGrpcService.Models;
using DatabaseGrpcService.Protos;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseGrpcService.ApplicationServices
{
	internal class GrpcService : Protos.DatabaseGrpcService.DatabaseGrpcServiceBase
	{
		#region Fields

		private readonly IMapperService _mapperService;
		private readonly IBusRepository _busRepository;
		private readonly IRouteRepository _routeRepository;
		private readonly IStopRepository _stopRepository;
		private readonly ITicketRepository _ticketRepository;
		private readonly IPassengerRepository _passengerRepository;
		private readonly IFobRepository _fobRepository;
		private readonly INfcRepository _nfcRepository;
		private readonly ILogger<GrpcService> _logger;

		#endregion

		#region Constructor

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
			_mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
			_busRepository = busRepository ?? throw new ArgumentNullException(nameof(busRepository));
			_routeRepository = routeRepository ?? throw new ArgumentNullException(nameof(routeRepository));
			_stopRepository = stopRepository ?? throw new ArgumentNullException(nameof(stopRepository));
			_ticketRepository = ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
			_passengerRepository = passengerRepository ?? throw new ArgumentNullException(nameof(passengerRepository));
			_fobRepository = fobRepository ?? throw new ArgumentNullException(nameof(fobRepository));
			_nfcRepository = nfcRepository ?? throw new ArgumentNullException(nameof(nfcRepository));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		#endregion

		#region Bus

		public override async Task<Response> CreateBus(Bus request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

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

		public override async Task<Bus> GetBus(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				BusDao bus = await _busRepository.GetAsync(request.Id);
				return _mapperService.MapFromDaoToProto<BusDao, Bus>(bus);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return _mapperService.MapFromDaoToProto<BusDao, Bus>(new BusDao());
		}

		public override async Task<BusList> GetAllBusses(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				List<BusDao> buses = await _busRepository.GetAllAsync();

				BusList busList = new();

				foreach (BusDao bus in buses)
				{
					busList.Busses.Add(_mapperService.MapFromDaoToProto<BusDao, Bus>(bus));
				}

				return busList;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return _mapperService.MapFromDaoToProto<List<Bus>, BusList>(new List<Bus>());
		}

		public override async Task<Response> UpdateBus(Bus request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _busRepository.UpdateAsync(_mapperService.MapFromProtoToDao<Bus, BusDao>(request));
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		public override async Task<Response> DeleteBus(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _busRepository.DeleteAsync(new BusDao { id = request.Id });
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		#endregion

		#region Route

		public override async Task<Response> CreateRoute(Route request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

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

		public override async Task<Route> GetRoute(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				RouteDao route = await _routeRepository.GetAsync(request.Id);
				return _mapperService.MapFromDaoToProto<RouteDao, Route>(route);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return _mapperService.MapFromDaoToProto<RouteDao, Route>(new RouteDao());
		}

		public override async Task<RouteList> GetAllRoutes(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				List<RouteDao> routes = await _routeRepository.GetAllAsync();

				RouteList routeList = new();

				foreach (RouteDao route in routes)
				{
					routeList.Routes.Add(_mapperService.MapFromDaoToProto<RouteDao, Route>(route));
				}

				return routeList;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return _mapperService.MapFromDaoToProto<List<RouteDao>, RouteList>(new List<RouteDao>());
		}

		public override async Task<Response> UpdateRoute(Route request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _routeRepository.UpdateAsync(_mapperService.MapFromProtoToDao<Route, RouteDao>(request));
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		public override async Task<Response> DeleteRoute(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _routeRepository.DeleteAsync(new RouteDao { id = request.Id });
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		#endregion

		#region Stop

		public override async Task<Response> CreateStop(Stop request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _stopRepository.InsertAsync(_mapperService.MapFromProtoToDao<Stop, StopDao>(request));
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		public override async Task<Stop> GetStop(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				StopDao stop = await _stopRepository.GetAsync(request.Id);
				return _mapperService.MapFromDaoToProto<StopDao, Stop>(stop);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return _mapperService.MapFromDaoToProto<StopDao, Stop>(new StopDao());
		}

		public override async Task<StopList> GetAllStops(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				List<StopDao> stops = await _stopRepository.GetAllAsync();

				StopList stopList = new();

				foreach (StopDao stop in stops)
				{
					stopList.Stops.Add(_mapperService.MapFromDaoToProto<StopDao, Stop>(stop));
				}

				return stopList;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return _mapperService.MapFromDaoToProto<List<StopDao>, StopList>(new List<StopDao>());
		}

		public override async Task<Response> UpdateStop(Stop request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _stopRepository.UpdateAsync(_mapperService.MapFromProtoToDao<Stop, StopDao>(request));
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		public override async Task<Response> DeleteStop(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _stopRepository.DeleteAsync(new StopDao { id = request.Id });
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		#endregion

		#region Ticket

		public override async Task<Response> CreateTicket(Ticket request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _ticketRepository.InsertAsync(_mapperService.MapFromProtoToDao<Ticket, TicketDao>(request));
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		public override async Task<Ticket> GetTicket(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				TicketDao stop = await _ticketRepository.GetAsync(request.Id);
				return _mapperService.MapFromDaoToProto<TicketDao, Ticket>(stop);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return _mapperService.MapFromDaoToProto<TicketDao, Ticket>(new TicketDao());
		}

		public override async Task<TicketList> GetAllTickets(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				List<TicketDao> tickets = await _ticketRepository.GetAllAsync();

				TicketList ticketList = new();

				foreach (TicketDao ticket in tickets)
				{
					ticketList.Tickets.Add(_mapperService.MapFromDaoToProto<TicketDao, Ticket>(ticket));
				}

				return ticketList;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return _mapperService.MapFromDaoToProto<List<TicketDao>, TicketList>(new List<TicketDao>());
		}

		public override async Task<Response> UpdateTicket(Ticket request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _ticketRepository.UpdateAsync(_mapperService.MapFromProtoToDao<Ticket, TicketDao>(request));
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		public override async Task<Response> DeleteTicket(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _ticketRepository.DeleteAsync(new TicketDao { id = request.Id });
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		#endregion

		#region Passenger

		public override async Task<Response> CreatePassenger(Passenger request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _passengerRepository.InsertAsync(_mapperService.MapFromProtoToDao<Passenger, PassengerDao>(request));
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		public override async Task<Passenger> GetPassenger(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				PassengerDao stop = await _passengerRepository.GetAsync(request.Id);
				return _mapperService.MapFromDaoToProto<PassengerDao, Passenger>(stop);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return _mapperService.MapFromDaoToProto<PassengerDao, Passenger>(new PassengerDao());
		}

		public override async Task<PassengerList> GetAllPassengers(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				List<PassengerDao> passengers = await _passengerRepository.GetAllAsync();

				PassengerList passengerList = new();

				foreach (PassengerDao passenger in passengers)
				{
					passengerList.Passengers.Add(_mapperService.MapFromDaoToProto<PassengerDao, Passenger>(passenger));
				}

				return passengerList;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return _mapperService.MapFromDaoToProto<List<PassengerDao>, PassengerList>(new List<PassengerDao>());
		}

		public override async Task<Response> UpdatePassenger(Passenger request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _passengerRepository.UpdateAsync(_mapperService.MapFromProtoToDao<Passenger, PassengerDao>(request));
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		public override async Task<Response> DeletePassenger(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _passengerRepository.DeleteAsync(new PassengerDao { id = request.Id });
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		#endregion

		#region Fob

		public override async Task<Response> CreateFob(Fob request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _fobRepository.InsertAsync(_mapperService.MapFromProtoToDao<Fob, FobDao>(request));
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		public override async Task<Fob> GetFob(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				FobDao fob = await _fobRepository.GetAsync(request.Id);
				return _mapperService.MapFromDaoToProto<FobDao, Fob>(fob);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return _mapperService.MapFromDaoToProto<FobDao, Fob>(new FobDao());
		}

		public override async Task<FobList> GetAllFobs(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				List<FobDao> fobs = await _fobRepository.GetAllAsync();

				FobList fobList = new();

				foreach (FobDao fob in fobs)
				{
					fobList.Fobs.Add(_mapperService.MapFromDaoToProto<FobDao, Fob>(fob));
				}

				return fobList;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return _mapperService.MapFromDaoToProto<List<FobDao>, FobList>(new List<FobDao>());
		}

		public override async Task<Response> UpdateFob(Fob request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _fobRepository.UpdateAsync(_mapperService.MapFromProtoToDao<Fob, FobDao>(request));
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		public override async Task<Response> DeleteFob(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _fobRepository.DeleteAsync(new FobDao { id = request.Id });
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		#endregion

		#region Nfc

		public override async Task<Response> CreateNfc(Nfc request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _nfcRepository.InsertAsync(_mapperService.MapFromProtoToDao<Nfc, NfcDao>(request));
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		public override async Task<Nfc> GetNfc(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				NfcDao stop = await _nfcRepository.GetAsync(request.Id);
				return _mapperService.MapFromDaoToProto<NfcDao, Nfc>(stop);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return _mapperService.MapFromDaoToProto<NfcDao, Nfc>(new NfcDao());
		}

		public override async Task<NfcList> GetAllNfcs(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				List<NfcDao> nfcs = await _nfcRepository.GetAllAsync();

				NfcList nfcList = new();

				foreach (NfcDao nfc in nfcs)
				{
					nfcList.Nfcs.Add(_mapperService.MapFromDaoToProto<NfcDao, Nfc>(nfc));
				}

				return nfcList;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return _mapperService.MapFromDaoToProto<List<NfcDao>, NfcList>(new List<NfcDao>());
		}

		public override async Task<Response> UpdateNfc(Nfc request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _nfcRepository.UpdateAsync(_mapperService.MapFromProtoToDao<Nfc, NfcDao>(request));
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		public override async Task<Response> DeleteNfc(Request request, ServerCallContext context)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			try
			{
				_ = await _nfcRepository.DeleteAsync(new NfcDao { id = request.Id });
				return new Response { Succeeded = true };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}

			return new Response { Succeeded = false };
		}

		#endregion
	}
}
