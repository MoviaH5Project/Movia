using Dapper.Contrib.Extensions;

namespace DatabaseGrpcService.Models
{
	[Table("passenger")]
	public class PassengerDao
	{
		[Key]
		public int id { get; set; }
		public string name { get; set; }
	}
}
