using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fcz.Navi.Api.WebApi.MiddleWares
{
	public class LowerJsonNamingPolicy : JsonNamingPolicy
	{
		public override string ConvertName(string name) => name.ToLower();
	}
}
