using Dapper.Contrib.Extensions;
using System;

namespace DatabaseGrpcService.Models
{
	[Table("ticket")]
	public class TicketDao
	{
		[Key]
		public int id { get; set; }
		public int busid { get; set; }
		public int passengerid { get; set; }
		public DateTime purchasetime { get; set; }
		public DateTime departuretime { get; set; }
		public int departurestopid { get; set; }
		public int destinationstopid { get; set; }
		public float price { get; set; }
		public bool checkedout { get; set; }
	}
}
