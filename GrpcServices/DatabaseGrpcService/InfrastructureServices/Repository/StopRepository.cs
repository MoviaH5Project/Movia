using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface IStopRepository : IBaseRepository<StopDao>
	{
	}
	public class StopRepository : BaseRepository<StopDao>, IStopRepository
	{
		public StopRepository(IDbConnection dbConnection, ILogger<StopRepository> logger) : base(dbConnection, logger)
		{
			if (dbConnection is null)
			{
				throw new ArgumentNullException(nameof(dbConnection));
			}

			if (logger is null)
			{
				throw new ArgumentNullException(nameof(logger));
			}
		}
	}
}
