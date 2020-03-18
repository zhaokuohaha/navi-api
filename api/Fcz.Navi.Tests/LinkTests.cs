using Fcz.Navi.Api.Services.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Fcz.Navi.Tests
{
	[TestClass]
	public class LinkTests
	{
		[TestMethod]
		public async Task TestColor()
		{
			var icon = "https://www.sogou.com/favicon.ico";
			var color = await LinkHelper.GetMainColor(icon);
		}

		[TestMethod]
		public async Task TestTld()
		{
			//var url = "https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/configure-language-version";
			var url = "https://www.oschina.net/";
			var icon = await LinkHelper.GetFavicon(url);
		}
	}
}
