using FamiliarBudgetApi.BLL;
using FamiliarBudgetApi.BLL.DTOs;
using FamiliarBudgetApi.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamiliarBudgetApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService bll)
        {
            this.userService = bll;
        }

        [HttpPost]
        public ActionResult Post(UserDTO user)
        {
            var userDB = userService.Insert(user);
            if (userDB == null)
            {
                return BadRequest("Could not create user");
            };
            
            return Ok(userDB);
        }


        [HttpGet]
        public ActionResult<List<UserDTO>> GetAll(string family) {
            return userService.GetAll(family);
        }

        [HttpGet("{familyCode}/{id:int}", Name="getUser")]
        public ActionResult<UserDTO> Get(string familyCode,int id)
        {
            return null;
        }
    }
}
