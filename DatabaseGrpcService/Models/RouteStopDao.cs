using Dapper.Contrib.Extensions;

namespace DatabaseGrpcService.Models
{
	[Table("routestop")]
	public class RouteStopDao
	{
		public int routeid { get; set; }
		public int stopid { get; set; }
	}
}
