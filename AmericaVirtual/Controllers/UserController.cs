using AmericaVirtual.Model.DTOs;
using AmericaVirtual.Model.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmericaVirtual.Controllers
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
        public ActionResult<UserDto> LogIn(string email, string password)
        {
            return Ok(service.GetUserInformationByEmail(email, password));
        }

        [HttpHead]
        public IActionResult LogOut(int userId)
        {
            service.LogOut(userId);
            return Ok();
        }

        [HttpDelete]
        public IActionResult RemoveUser(int userId)
        {
            service.RemoveUser(userId);
            return Ok();
        }

        [HttpPost]
        public ActionResult<int> UserPurchase(int userId, int productId)
        {
            return Ok(service.UserPurchase(userId, productId));
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
