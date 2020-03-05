using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fcz.Navi.Api.Models.Entities
{
	[Table("nuser")]
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Pwd { get; set; }
		public DateTime? CreateTime { get; set; }

		public DateTime? DeleteTime { get; set; }
	}
}
