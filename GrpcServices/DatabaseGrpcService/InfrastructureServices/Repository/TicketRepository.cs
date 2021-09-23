using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface ITicketRepository : IBaseRepository<TicketDao>
	{
	}
	public class TicketRepository : BaseRepository<TicketDao>, ITicketRepository
	{
		public TicketRepository(IDbConnection dbConnection, ILogger<TicketRepository> logger) : base(dbConnection, logger)
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
