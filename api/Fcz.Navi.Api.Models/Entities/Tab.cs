using System.ComponentModel.DataAnnotations.Schema;

namespace Fcz.Navi.Api.Models.Entities
{
	[Table("ntab")]
	public class Tab
	{
		public string Id { get; set; }
		public string UserId { get; set; }
		public string Title { get; set; }
		public string CreateTime { get; set; }
		public string DeleteTime { get; set; }
	}
}