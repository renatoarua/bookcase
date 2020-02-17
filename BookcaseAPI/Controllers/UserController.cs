using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service.Interface;

namespace BookcaseAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _userService.userTake(id));
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TabUser user)
        {
            var saved = await _userService.userSave(user);

            if (!saved) return BadRequest("Email or username is being used.");

            return Ok(saved);
        }
    }
}
