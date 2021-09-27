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
		Task<NfcDao> GetNfcByUuid(string uuid);
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

		public async Task<NfcDao> GetNfcByUuid(string uuid)
		{
			_logger.LogInformation("Getting entity {uuid} of type {type}", uuid, typeof(NfcDao).Name);

			try
			{
				 return await _dbConnection.QuerySingleAsync<NfcDao>("SELECT * FROM nfc WHERE uuid = @uuid;", new { uuid });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Something went wrong when trying to get entity {id} of type {type}", uuid, typeof(NfcDao).Name);
				throw;
			}
		}
	}
}
