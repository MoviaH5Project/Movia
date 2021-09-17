using Dapper.Contrib.Extensions;

namespace DatabaseGrpcService.Models
{
	[Table("route")]
	public class RouteDao
	{
		[Key]
		public int id { get; set; }
		public string name { get; set; }
	}
}
