using ColorThiefDotNet;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Nager.PublicSuffix;
using Fcz.Navi.Api.Models.Entities;
using System.Text.RegularExpressions;

namespace Fcz.Navi.Api.Services.Internal
{
	public class LinkHelper
	{

		public static async Task<string> GetMainColor(string imageUrl)
		{
			using var hc = new HttpClient();
			var stream = await hc.GetStreamAsync(imageUrl);
			var image = new Bitmap(stream);

			var ct = new ColorThief();
			var color = ct.GetColor(image);
			return color.Color.ToHexString();
		}

		public static async Task<string> GetFavicon(string url)
		{
			var uri = new Uri(url);
			var icon = await GetFromUri();
			if (icon == null)
				icon = await GetFromContent();
			return icon;

			async Task<string> GetFromContent()
			{
				using var hc = new HttpClient { Timeout = TimeSpan.FromSeconds(2) };
				var content = await hc.TryGetStringAsync(uri);
				var reg = new Regex("<link.*?href=\"(.*)\\.ico");
				var match = reg.Match(content);
				if (match.Success)
				{
					return match.Groups[1].Value + ".ico";
				}
				return null;
			}

			async Task<string> GetFromUri()
			{
				var domain = new DomainParser(new WebTldRuleProvider()).Get(uri);
				var iconPath = "favicon.ico";
				var links = new[]
				{
					$"{uri.Scheme}://{domain.Hostname}/{iconPath}",
					$"{uri.Scheme}://{domain.RegistrableDomain}/{iconPath}",
					$"{uri.Scheme}://www.{domain.RegistrableDomain}/{iconPath}"
				};
				using var hc = new HttpClient { Timeout = TimeSpan.FromSeconds(1) };
				foreach (var link in links)
				{
					var res = await hc.TryGetAsync(link);
					if (res!=null && res.IsSuccessStatusCode)
						return link;
				}
				return null;
			}
		}
	}

	internal static class HttpClientExtensions
	{
		internal static async Task<HttpResponseMessage> TryGetAsync(this HttpClient client, string url)
		{
			try
			{
				return await client.GetAsync(url);
			}
			catch
			{
					return null;
			}
		}

		internal static async Task<string> TryGetStringAsync(this HttpClient client, Uri url)
		{
			try
			{
				return await client.GetStringAsync(url);
			}
			catch
			{
				return string.Empty;
			}
		}
	}
}
