using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;
using System.Data;

namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface IBusRepository : IBaseRepository<BusDao>
	{
	}

	public class BusRepository : BaseRepository<BusDao>, IBusRepository
	{
		public BusRepository(IDbConnection dbConnection, ILogger<BusRepository> logger) : base(dbConnection, logger) { }
	}
}
