using Dapper.Contrib.Extensions;

namespace DatabaseGrpcService.Models
{
	[Table("fob")]
	public class FobDao
	{
		[Key]
		public int id { get; set; }
		public string macaddress { get; set; }
		public int passengerid { get; set; }
	}
}
