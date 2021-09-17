using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;

using System.Data;
namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface IRouteRepository : IBaseRepository<RouteDao>
	{
	}
	public class RouteRepository : BaseRepository<RouteDao>, IRouteRepository
	{
		public RouteRepository(IDbConnection dbConnection, ILogger<RouteRepository> logger) : base(dbConnection, logger) { }
	}
}
