using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fcz.Navi.Api.Models.Entities
{
	[Table("ntab")]
	public class Tab
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Title { get; set; }
		public DateTime? CreateTime { get; set; }
		public DateTime? DeleteTime { get; set; }
	}
}