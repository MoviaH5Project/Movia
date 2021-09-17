using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;
using System.Data;

namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface IPassengerRepository : IBaseRepository<PassengerDao>
	{
	}

	public class PassengerRepository : BaseRepository<PassengerDao>, IPassengerRepository
	{
		public PassengerRepository(IDbConnection dbConnection, ILogger<PassengerRepository> logger) : base(dbConnection, logger) { }
	}
}
