using Google.Protobuf;
using Grpc.Core;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TicketGrpcService.Helpers;
using TicketGrpcService.InfrastructureServices;
using Database = DatabaseGrpcService.Protos;

namespace TicketGrpcService.ApplicationServices
{
	internal class TicketGrpcService : Protos.TicketGrpcService.TicketGrpcServiceBase
	{
		private const string _serviceContainerName = "ticket_service";

		private readonly IDatabaseGrpcService _databaseGrpcService;
		private readonly ILogHelper<TicketGrpcService> _logHelper;

		public TicketGrpcService(IDatabaseGrpcService databaseGrpcService, ILogHelper<TicketGrpcService> logHelper)
		{
			_databaseGrpcService = databaseGrpcService ?? throw new ArgumentNullException(nameof(databaseGrpcService));
			_logHelper = logHelper ?? throw new ArgumentNullException(nameof(logHelper));
		}

		public override async Task<Protos.Response> CreateTicket(Protos.Ticket request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.CreateTicketAsync(Database.Ticket.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Ticket> GetTicket(Protos.Request request, ServerCallContext context)
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
				return Protos.Ticket.Parser.ParseFrom((await _databaseGrpcService.GetTicketAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.TicketList> GetAllTickets(Protos.Request request, ServerCallContext context)
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
				return Protos.TicketList.Parser.ParseFrom((await _databaseGrpcService.GetAllTicketsAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> UpdateTicket(Protos.Ticket request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.UpdateTicketAsync(Database.Ticket.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> DeleteTicket(Protos.Request request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.DeleteTicketAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> CreatePassenger(Protos.Passenger request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.CreatePassengerAsync(Database.Passenger.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Passenger> GetPassenger(Protos.Request request, ServerCallContext context)
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
				return Protos.Passenger.Parser.ParseFrom((await _databaseGrpcService.GetPassengerAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.PassengerList> GetAllPassengers(Protos.Request request, ServerCallContext context)
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
				return Protos.PassengerList.Parser.ParseFrom((await _databaseGrpcService.GetAllPassengersAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> UpdatePassenger(Protos.Passenger request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.UpdatePassengerAsync(Database.Passenger.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> DeletePassenger(Protos.Request request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.DeletePassengerAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> CreateFob(Protos.Fob request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.CreateFobAsync(Database.Fob.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Fob> GetFob(Protos.Request request, ServerCallContext context)
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
				return Protos.Fob.Parser.ParseFrom((await _databaseGrpcService.GetFobAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.FobList> GetAllFobs(Protos.Request request, ServerCallContext context)
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
				return Protos.FobList.Parser.ParseFrom((await _databaseGrpcService.GetAllFobsAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> UpdateFob(Protos.Fob request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.UpdateFobAsync(Database.Fob.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> DeleteFob(Protos.Request request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.DeleteFobAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Fob> GetFobByNfc(Protos.Nfc request, ServerCallContext context)
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

				Database.NfcList nfcList = await _databaseGrpcService.GetAllNfcsAsync(new Database.Request { Id = 1 });

				Database.Nfc nfc = nfcList.Nfcs.Where(n => n.Uuid == request.Uuid).FirstOrDefault();

				return Protos.Fob.Parser.ParseFrom((await _databaseGrpcService.GetFobByPassengerIdAsync(new Database.Request { Id = nfc.PassengerId })).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> CreateNfc(Protos.Nfc request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.CreateNfcAsync(Database.Nfc.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Nfc> GetNfc(Protos.Request request, ServerCallContext context)
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
				return Protos.Nfc.Parser.ParseFrom((await _databaseGrpcService.GetNfcAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.NfcList> GetAllNfcs(Protos.Request request, ServerCallContext context)
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
				return Protos.NfcList.Parser.ParseFrom((await _databaseGrpcService.GetAllNfcsAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> UpdateNfc(Protos.Nfc request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.UpdateNfcAsync(Database.Nfc.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public override async Task<Protos.Response> DeleteNfc(Protos.Request request, ServerCallContext context)
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
				return Protos.Response.Parser.ParseFrom((await _databaseGrpcService.DeleteNfcAsync(Database.Request.Parser.ParseFrom(request.ToByteArray()))).ToByteArray());
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}
	}
}
