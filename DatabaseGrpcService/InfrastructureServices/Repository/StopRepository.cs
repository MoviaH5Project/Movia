using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;

using System.Data;
namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface IStopRepository : IBaseRepository<StopDao>
	{
	}
	public class StopRepository : BaseRepository<StopDao>, IStopRepository
	{
		public StopRepository(IDbConnection dbConnection, ILogger<StopRepository> logger) : base(dbConnection, logger) { }
	}
}
