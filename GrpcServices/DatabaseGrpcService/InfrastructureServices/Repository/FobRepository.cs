using Dapper;
using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface IFobRepository : IBaseRepository<FobDao>
	{
		Task<FobDao> GetFobByPassengerId(int passengerId);
	}

	public class FobRepository : BaseRepository<FobDao>, IFobRepository
	{
		private readonly IDbConnection _dbConnection;
		private readonly ILogger<FobRepository> _logger;

		public FobRepository(IDbConnection dbConnection, ILogger<FobRepository> logger) : base(dbConnection, logger)
		{
			_dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task<FobDao> GetFobByPassengerId(int passengerId)
		{
			_logger.LogInformation("Getting entity {entity} of type {type}", passengerId, typeof(FobDao).Name);

			try
			{
				return await _dbConnection.QuerySingleAsync<FobDao>("SELECT * FROM fob WHERE passengerid = @passengerid;", new { passengerid = passengerId });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Something went wrong when trying to get entity {entity} of type {type}", passengerId, typeof(FobDao).Name);
				throw;
			}
		}
	}
}
