using Business.Abstract;
using Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult ChangeToPassword([FromForm]UserForLoginDto userForLoginDto,[FromForm]string newPassword)
        {
            var result = _userService.ChangeToPassword(userForLoginDto, newPassword);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
