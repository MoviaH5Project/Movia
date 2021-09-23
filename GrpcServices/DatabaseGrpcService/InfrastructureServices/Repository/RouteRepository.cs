using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface IRouteRepository : IBaseRepository<RouteDao>
	{
	}
	public class RouteRepository : BaseRepository<RouteDao>, IRouteRepository
	{
		public RouteRepository(IDbConnection dbConnection, ILogger<RouteRepository> logger) : base(dbConnection, logger)
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
