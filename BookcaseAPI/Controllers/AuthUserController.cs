using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Models;
using Service.Interface;

namespace BookcaseAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public AuthUserController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> AuthUser([FromBody]AuthUser authUser)
        {
            TabUser user = await _userService.authUser(authUser);

            if (user == null) return BadRequest("Senha ou email inválidos!");

            var claims = new[]
            {
                new Claim("id", user.UserId.ToString()),
                new Claim("userName", user.UserName),
                new Claim("fullName", user.UserFullName),
                new Claim("email", user.UserEmail)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Code Cave Web Solution",
                audience: user.UserEmail,
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: creds                
                );

            Response.Headers.Add("x-access-token", new JwtSecurityTokenHandler().WriteToken(token));


            return Ok();
            //return Ok(new
            //{
            //    token = new JwtSecurityTokenHandler().WriteToken(token)
            //});
        }
    }
}
