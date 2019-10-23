using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapi_playground.Managers;
using webapi_playground.Models;

namespace webapi_playground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var mgr = new UsersManager();
            return mgr.GetUsers();
        }

        [HttpPost]
        public ActionResult<int> Post(User user)
        {
            var mgr = new UsersManager();
            return mgr.AddUser(user);
        }
    }
}