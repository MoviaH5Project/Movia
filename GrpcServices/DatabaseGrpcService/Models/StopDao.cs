using Dapper.Contrib.Extensions;

namespace DatabaseGrpcService.Models
{
	[Table("stop")]
	public class StopDao
	{
		[Key]
		public int id { get; set; }
		public string name { get; set; }
		public string latitude { get; set; }
		public string longitude { get; set; }
	}
}
