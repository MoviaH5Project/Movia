using Dapper.Contrib.Extensions;

namespace DatabaseGrpcService.Models
{
	[Table("nfc")]
	public class NfcDao
	{
		[Key]
		public int id { get; set; }
		public string uuid { get; set; }
		public int passengerid { get; set; }
	}
}
