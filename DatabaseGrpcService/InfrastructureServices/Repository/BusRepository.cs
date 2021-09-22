using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Data;

namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface IBusRepository : IBaseRepository<BusDao>
	{
	}

	public class BusRepository : BaseRepository<BusDao>, IBusRepository
	{
		public BusRepository(IDbConnection dbConnection, ILogger<BusRepository> logger) : base(dbConnection, logger)
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
