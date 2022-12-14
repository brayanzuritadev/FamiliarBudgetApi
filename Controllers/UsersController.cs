using FamiliarBudgetApi.Data.DTOs;
using FamiliarBudgetApi.Data.Models;
using FamiliarBudgetApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamiliarBudgetApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {

            this.userService = userService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = ("1"))]
        public ActionResult<User> GetAll()
        {
            var users = userService.GetAll();

            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public ActionResult<UserDTO> Get(int id) 
        {
            var user = userService.GetUserById(id);

            if (user==null)
            {
                return BadRequest("There is no user with that ID");
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<AuthenticationResponse> Post(UserDTO user)
        {

            var tokenUserCreate = userService.Insert(user);

            if (tokenUserCreate == null)
            {
                return BadRequest("Could not create user");
            };

            return Ok(new { response = tokenUserCreate });
        }

        [HttpDelete ("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (!userService.Delete(id))
            {
                return BadRequest("Could not delete user");
            }
            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(UserDTO user,int id)
        {
            user.ID=id;

            if (!userService.UpdateUser(user))
            {
                return BadRequest("Could not update user");
            }
            return Ok();
        }

    }
}
