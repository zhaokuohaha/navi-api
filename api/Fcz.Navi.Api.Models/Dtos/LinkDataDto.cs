using System;

namespace Fcz.Navi.Api.Models.Dtos
{
	public class LinkDataDto
	{
        public int Id { get; set; }
		public int TabId { get; set; }
        public string TabTitle { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string BgColor { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
	}
}