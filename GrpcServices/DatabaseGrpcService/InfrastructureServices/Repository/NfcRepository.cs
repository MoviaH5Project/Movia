using Dapper;
using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface INfcRepository : IBaseRepository<NfcDao>
	{
		Task<NfcDao> GetNfcByPassengerId(int passengerId);
	}

	public class NfcRepository : BaseRepository<NfcDao>, INfcRepository
	{
		private readonly IDbConnection _dbConnection;
		private readonly ILogger<NfcRepository> _logger;

		public NfcRepository(IDbConnection dbConnection, ILogger<NfcRepository> logger) : base(dbConnection, logger)
		{
			_dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task<NfcDao> GetNfcByPassengerId(int passengerId)
		{
			_logger.LogInformation("Getting entity {entity} of type {type}", passengerId, typeof(NfcDao).Name);

			try
			{
				return await _dbConnection.QuerySingleAsync<NfcDao>("SELECT * FROM nfc WHERE passengerid = @passengerid;", new { passengerid = passengerId });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Something went wrong when trying to get entity {entity} of type {type}", passengerId, typeof(NfcDao).Name);
				throw;
			}
		}
	}
}
