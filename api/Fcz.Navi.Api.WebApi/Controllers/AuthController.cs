using Fcz.Navi.Api.Models.Dtos;
using Fcz.Navi.Api.Models.Entities;
using Fcz.Navi.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace Fcz.Navi.Api.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly TokenValidationParameters _jwtParam;
		public AuthController(IUserService userService, TokenValidationParameters jwtParam)
		{
			_userService = userService;
			_jwtParam = jwtParam;
			
		}

		[HttpPost]
		public async Task<ActionResult> Login([FromBody] AuthDto dto)
		{
			var user = await _userService.Get(dto.UserName);
			if(user != null && _userService.CheckPwd(user, dto.Password))
			{
				var token = GenerateJSONWebToken(user);
				return Ok(new { access_token = token});
			}
			return Unauthorized();
		}

		private string GenerateJSONWebToken(User user)
		{
			var credentials = new SigningCredentials(_jwtParam.IssuerSigningKey, SecurityAlgorithms.HmacSha256);
			var claims = new Claim[]
			{
				new Claim("Id", user.Id.ToString()),
				new Claim("Name", user.Name)
			};
			var token = new JwtSecurityToken(
				_jwtParam.ValidIssuer,
				_jwtParam.ValidAudience,
			  claims,
			  expires: DateTime.Now.AddMinutes(120),
			  signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
