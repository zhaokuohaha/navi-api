using System.ComponentModel.DataAnnotations.Schema;

namespace Fcz.Navi.Api.Models.Entities
{
	[Table("nlink")]
	public class Link
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public string Icon { get; set; }
		public string BgColor { get; set; }
		public string CreateTime { get; set; }
		public string DeleteTime { get; set; }
		public string TabId { get; set; }

	}
}