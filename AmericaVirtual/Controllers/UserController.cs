using Api.Core.Model.DTOs;
using Api.Core.Model.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService service;

        public UserController(IUserService userService)
        {
            service = userService;
        }

        [HttpPost]
        public ActionResult<long> AddUser([FromBody] UserDto user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(service.AddUser(user));
        }

        [HttpGet]
        public ActionResult<ProductDto> LogIn(string email)
        {
            return Ok(service.GetUserInformationByEmail(email));
        }

        [HttpDelete]
        public IActionResult RemoveUser(long userId)
        {
            service.RemoveUser(userId);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            service.UpdateUser(user);
            return Ok();
        }
    }
}
