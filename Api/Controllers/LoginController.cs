using Commerce.Repository.Models;
using Commerce.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] AuthenticateModel userLogin)
        {
            var token = _userService.Authenticate(userLogin);

            if (token != null)
            {
                return Ok(token);
            }

            return NotFound("User not found");
        }
    }
}
