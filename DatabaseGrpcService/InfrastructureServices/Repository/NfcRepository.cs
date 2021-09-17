using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;
using System.Data;

namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface INfcRepository : IBaseRepository<NfcDao>
	{
	}

	public class NfcRepository : BaseRepository<NfcDao>, INfcRepository
	{
		public NfcRepository(IDbConnection dbConnection, ILogger<NfcRepository> logger) : base(dbConnection, logger) { }
	}
}
