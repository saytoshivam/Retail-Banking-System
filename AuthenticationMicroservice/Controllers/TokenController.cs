using AuthenticationMicroservice.Models;
using AuthenticationMicroservice.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly IUserListRepo _userrepo;
        public static List<User> userList = new List<User>
        {
            new User{UserId=1,Password="1234",Roles="Employee"},
            new User{UserId=2,Password="12345",Roles="Customer"}
        };
        readonly log4net.ILog _log4net;
        public TokenController(IUserListRepo userrepo)
        {
            _userrepo = userrepo;
            _log4net = log4net.LogManager.GetLogger(typeof(TokenController));
        }
        [HttpPost]
        public async Task<IActionResult> Post(User u)
        {
            _log4net.Info("Login method generated");
            
            var v = _userrepo.getUserById(u.UserId);
            
                if (u.UserId == v.UserId && u.Password == v.Password)
                {
                    string role = "";
                    if (v.Roles == "Employee")
                        role = "Employee";
                    else
                        role = "Customer";
                    var result = new
                    {
                        token = GenerateJSONWebToken(u.UserId, role)
                    };
                    _log4net.Info("Token Generated");
                //return Ok(result);
                var x = GenerateJSONWebToken(u.UserId, role);
                // return Request.HttpContext.Response<string>(Ok,x);
                return new ContentResult
                {
                    Content = x,
                    ContentType = "text/plain",
                    StatusCode = 200
                };
                }
            
            _log4net.Info("Token Denied");
            return BadRequest();
        }
        private string GenerateJSONWebToken(int userId, string userRole)
        {
            _log4net.Info("Token Generation Initiated");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {

                new Claim(ClaimTypes.Role, userRole),

                new Claim("UserId", userId.ToString())

            };

            var token = new JwtSecurityToken(

            issuer: "mySystem",

            audience: "myUsers",

            claims: claims,

            expires: DateTime.Now.AddMinutes(100),

            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
