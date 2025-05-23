using Application.Interfaces;
using Domain.Class;
using Microsoft.AspNetCore.Mvc;

namespace PruebaMakers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        readonly IApplicationUser ApplicationUser;
        public UserController(IApplicationUser applicationUser)
        {
            ApplicationUser = applicationUser;
        }


        [HttpGet]
        public UserDomain[] GetAllUsers()
        {
            return ApplicationUser.GetAllUsers();
        }

        [HttpGet]
        [Route("{id}")]
        public UserDomain GetUserById(int id)
        {
            return ApplicationUser.GetUserById(id);
        }
    }
}
