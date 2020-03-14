using Fcz.Navi.Api.Services;
using Fcz.Navi.Api.WebApi.MiddleWares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Text.Json;

namespace Fcz.Navi.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		private readonly string NaviOrigin = "AllowOrigin";

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddControllers()
				.AddJsonOptions(options => {
					// 返回body字段全部改成小写
					options.JsonSerializerOptions.PropertyNamingPolicy = new LowerJsonNamingPolicy();
					// 接收参数忽略大小写
					options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
				});
			//services.AddSingleton<IServiceProvider>();
			
			services.AddNaviService(Configuration);
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Navi接口列表", Version = "v1" });
			});
			services.AddCors(options =>
			{
				options.AddPolicy(NaviOrigin,
					builder => { builder.WithOrigins("http://localhost:8080", "https://navi.oldzeng.com"); });
			});

			// 使用小写路径
			services.AddRouting(options =>
			{
				options.LowercaseUrls = true;
				options.LowercaseQueryStrings = true;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Navi接口列表-V1");
				c.RoutePrefix = "doc";
			});
			app.UseCors(NaviOrigin);

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
