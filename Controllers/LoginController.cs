
using FamiliarBudgetApi.Data.DTOs;
using FamiliarBudgetApi.Data.Models;
using FamiliarBudgetApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FamiliarBudgetApi.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService service;
        public LoginController(ILoginService service)
        {
            this.service = service;
        }


        [HttpPost]
        public ActionResult<string> Login(UserDTO user)
        {
            var token = service.Login(user);
            if (token==null)
            {
                return BadRequest("Verify your email and password");
            }
            
            return Ok(new { response = token });
        }
    }
}
