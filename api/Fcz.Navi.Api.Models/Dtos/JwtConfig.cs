using System;
using System.Collections.Generic;
using System.Text;

namespace Fcz.Navi.Api.Models.Dtos
{
	public class JwtConfig
	{
		public string Audience { get; set; }
		public string Issuer { get; set; }
		public string Key { get; set; }
	}
}
