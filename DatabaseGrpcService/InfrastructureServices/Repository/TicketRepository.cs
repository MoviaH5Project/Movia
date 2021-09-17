using DatabaseGrpcService.Models;
using Microsoft.Extensions.Logging;

using System.Data;
namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface ITicketRepository : IBaseRepository<TicketDao>
	{
	}
	public class TicketRepository : BaseRepository<TicketDao>, ITicketRepository
	{
		public TicketRepository(IDbConnection dbConnection, ILogger<TicketRepository> logger) : base(dbConnection, logger) { }
	}
}
