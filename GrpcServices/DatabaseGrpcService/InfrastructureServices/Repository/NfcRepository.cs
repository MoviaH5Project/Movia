using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Data;

namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface INfcRepository : IBaseRepository<NfcDao>
	{
	}

	public class NfcRepository : BaseRepository<NfcDao>, INfcRepository
	{
		public NfcRepository(IDbConnection dbConnection, ILogger<NfcRepository> logger) : base(dbConnection, logger)
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
