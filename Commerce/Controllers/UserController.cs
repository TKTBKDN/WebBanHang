using Commerce.Repository.Models;
using Commerce.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Commerce.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(UserModel model)
        {
           var res = await _userService.AddUser(model);
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel authenticateModel)
        {
            var result =  _userService.Authenticate(authenticateModel);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
