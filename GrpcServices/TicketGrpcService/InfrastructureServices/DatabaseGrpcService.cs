using System;
using System.Reflection;
using System.Threading.Tasks;
using TicketGrpcService.Helpers;
using Database = DatabaseGrpcService.Protos;

namespace TicketGrpcService.InfrastructureServices
{
	internal interface IDatabaseGrpcService
	{
		Task<Database.Response> CreateFobAsync(Database.Fob request);
		Task<Database.Response> CreateNfcAsync(Database.Nfc request);
		Task<Database.Response> CreatePassengerAsync(Database.Passenger request);
		Task<Database.Response> CreateTicketAsync(Database.Ticket request);
		Task<Database.Response> DeleteFobAsync(Database.Request request);
		Task<Database.Response> DeleteNfcAsync(Database.Request request);
		Task<Database.Response> DeletePassengerAsync(Database.Request request);
		Task<Database.Response> DeleteTicketAsync(Database.Request request);
		Task<Database.FobList> GetAllFobsAsync(Database.Request request);
		Task<Database.NfcList> GetAllNfcsAsync(Database.Request request);
		Task<Database.PassengerList> GetAllPassengersAsync(Database.Request request);
		Task<Database.TicketList> GetAllTicketsAsync(Database.Request request);
		Task<Database.Fob> GetFobAsync(Database.Request request);
		Task<Database.Nfc> GetNfcAsync(Database.Request request);
		Task<Database.Passenger> GetPassengerAsync(Database.Request request);
		Task<Database.Ticket> GetTicketAsync(Database.Request request);
		Task<Database.Response> UpdateFobAsync(Database.Fob request);
		Task<Database.Response> UpdateNfcAsync(Database.Nfc request);
		Task<Database.Response> UpdatePassengerAsync(Database.Passenger request);
		Task<Database.Response> UpdateTicketAsync(Database.Ticket request);
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

		public async Task<Database.Response> CreateTicketAsync(Database.Ticket request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.CreateTicketAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Ticket> GetTicketAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.GetTicketAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.TicketList> GetAllTicketsAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.GetAllTicketsAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> UpdateTicketAsync(Database.Ticket request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.UpdateTicketAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> DeleteTicketAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.DeleteTicketAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> CreatePassengerAsync(Database.Passenger request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.CreatePassengerAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Passenger> GetPassengerAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.GetPassengerAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.PassengerList> GetAllPassengersAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.GetAllPassengersAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> UpdatePassengerAsync(Database.Passenger request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.UpdatePassengerAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> DeletePassengerAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.DeletePassengerAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> CreateFobAsync(Database.Fob request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.CreateFobAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Fob> GetFobAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.GetFobAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.FobList> GetAllFobsAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.GetAllFobsAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> UpdateFobAsync(Database.Fob request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.UpdateFobAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> DeleteFobAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.DeleteFobAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> CreateNfcAsync(Database.Nfc request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.CreateNfcAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Nfc> GetNfcAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.GetNfcAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.NfcList> GetAllNfcsAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.GetAllNfcsAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> UpdateNfcAsync(Database.Nfc request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.UpdateNfcAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}

		public async Task<Database.Response> DeleteNfcAsync(Database.Request request)
		{
			if (request is null)
			{
				_logHelper.LogNullException(nameof(request));
				throw new ArgumentNullException(nameof(request));
			}

			try
			{
				_logHelper.LogInvokingGrpcMethod(MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				return await _databaseGrpcServiceClient.DeleteNfcAsync(request);
			}
			catch (Exception ex)
			{
				_logHelper.LogErrorInvokingGrpcMethod(ex, MethodBase.GetCurrentMethod().Name, _serviceContainerName, request);
				throw;
			}
		}
	}
}
