using AutoMapper;
using DatabaseGrpcService.Models;
using DatabaseGrpcService.Protos;

namespace DatabaseGrpcService
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Bus, BusDao>();
			CreateMap<BusDao, Bus>();

			CreateMap<Stop, StopDao>();
			CreateMap<StopDao, Stop>();

			CreateMap<Route, RouteDao>();
			CreateMap<RouteDao, Route>();

			CreateMap<Ticket, TicketDao>();
			CreateMap<TicketDao, Ticket>();

			CreateMap<Passenger, PassengerDao>();
			CreateMap<PassengerDao, Passenger>();

			CreateMap<Nfc, NfcDao>();
			CreateMap<NfcDao, Nfc>();

			CreateMap<Fob, FobDao>();
			CreateMap<FobDao, Fob>();
		}
	}
}
