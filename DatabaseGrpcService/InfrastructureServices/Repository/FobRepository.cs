using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;
using System.Data;

namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface IFobRepository : IBaseRepository<FobDao>
	{
	}

	public class FobRepository : BaseRepository<FobDao>, IFobRepository
	{
		public FobRepository(IDbConnection dbConnection, ILogger<FobRepository> logger) : base(dbConnection, logger) { }
	}
}
