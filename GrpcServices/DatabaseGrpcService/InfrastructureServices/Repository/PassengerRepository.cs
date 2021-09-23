using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Data;

namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface IPassengerRepository : IBaseRepository<PassengerDao>
	{
	}

	public class PassengerRepository : BaseRepository<PassengerDao>, IPassengerRepository
	{
		public PassengerRepository(IDbConnection dbConnection, ILogger<PassengerRepository> logger) : base(dbConnection, logger)
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
