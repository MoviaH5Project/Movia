using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Data;

namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface IRouteStopsRepository : IBaseRepository<RouteStopDao>
	{
	}

	public class RouteStopsRepository : BaseRepository<RouteStopDao>, IRouteStopsRepository
	{
		public RouteStopsRepository(IDbConnection dbConnection, ILogger<RouteStopsRepository> logger) : base(dbConnection, logger)
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
