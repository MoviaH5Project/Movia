using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;
using System.Data;

namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface IRouteStopsRepository : IBaseRepository<RouteStopDao>
	{
	}

	public class RouteStopsRepository : BaseRepository<RouteStopDao>, IRouteStopsRepository
	{
		public RouteStopsRepository(IDbConnection dbConnection, ILogger<RouteStopsRepository> logger) : base(dbConnection, logger) { }
	}
}
