using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fcz.Navi.Api.Models.Entities
{
	[Table("nlink")]
	public class Link
	{
		[Key]
		public int Id { get; set; }
		public int TabId { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public string Icon { get; set; }
		public string BgColor { get; set; }
		public DateTime? CreateTime { get; set; }
		public DateTime? DeleteTime { get; set; }

	}
}