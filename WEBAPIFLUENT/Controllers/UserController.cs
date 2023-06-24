using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Repository;

namespace WEBAPIFLUENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            try
            {
                var res = await _repo.CheckUser(user);
                if (res == null)
                {
                    return Unauthorized("Invalid credentials");
                }
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Name)),
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, "Employee")
                     
                };
                //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                
                return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Signup([FromBody] UserDTO user)
        {
            try
            {
                var res=await _repo.AddUser(user);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }
        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromQuery] string Email)
        {
            try
            {
                string scheme=Request.Scheme;
                string host =scheme+"://"+ Request.Host.Host+":"+Request.Host.Port;
                var res=await  _repo.ResetPassword(Email,host);
                if (res == null) return NotFound("User Not Found.");

                return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.InnerException + ex.Message);
            }
        }
        [HttpGet("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromQuery] string token, [FromBody] UserDTO user)
        {
            try
            {
                var res=await _repo.ForgotPassword(token, user);
                switch (res)
                {
                    case 0:return BadRequest("Token Description Failed.");
                    case 1:return BadRequest("Time out Exception");
                    case 2:return BadRequest("User Id not Present");
                    case 3:return Ok("password updated successfully");
                    default:
                        return BadRequest("Internal Error occured");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.InnerException+ex.Message);
            }
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                return Ok("Logged Out Successfully.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        public IActionResult AccessDenied()
        {
            return StatusCode(403, "Privilizes are required.");
        }

    }
}
