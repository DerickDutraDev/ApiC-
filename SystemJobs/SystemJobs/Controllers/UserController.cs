using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemJobs.Models;

namespace SystemJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UserModel>> SearchAllUsers()
        {
            return Ok();
        }

    }
}
