using AlaadinWebAPIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace AlaadinWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTokenController : ControllerBase
    {
        private readonly Aladin_prp_dbContext _context;
        private Jwtsettings _jwtsettings;
        public UserTokenController(Aladin_prp_dbContext context,IOptions<Jwtsettings> options)
        {
            _context = context;
            _jwtsettings = options.Value;
        }
        [Route("Token")]
        [HttpPost]
        public IActionResult Authtoken([FromBody] AuthUser usertoken) 
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == usertoken.Username && x.Password==usertoken.Password);
            if (user == null)
            {
                return Unauthorized();
            }
                
                // Generate Token
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.UTF8.GetBytes(_jwtsettings.securitykey);
                var tokendesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity
                    (
                    new Claim[] { new Claim(ClaimTypes.Name, user.Password) }
                    ),
                    Expires = DateTime.Now.AddDays(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey),SecurityAlgorithms.HmacSha256)
                };
                var token = tokenhandler.CreateToken(tokendesc);
                string finaltoken = tokenhandler.WriteToken(token);
            return Ok(finaltoken);
        }
    }           
}
