using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using procedurewithADO.Models;

namespace procedurewithADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsers _users;
        public UserController(IUsers users) 
        { 
            _users=users;
        }





        [HttpPost("add")]
        public IActionResult AddUser([FromBody]UserDTO user)
        {
            int data=_users.AddUsers(user);
            return Ok(data);
        }


    }
}
