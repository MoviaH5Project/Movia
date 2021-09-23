using Dapper.Contrib.Extensions;

namespace DatabaseGrpcService.Models
{
	[Table("bus")]
	public class BusDao
	{
		[Key]
		public int id { get; set; }
		public string name { get; set; }
		public string make { get; set; }
		public string driver { get; set; }
		public int routeid { get; set; }
		public int totalbuscapacity { get; set; }
		public int currentbusoccupation { get; set; }
		public string latitude { get; set; }
		public string longitude { get; set; }
	}
}
