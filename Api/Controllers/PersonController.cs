using Microsoft.AspNetCore.Mvc;
using Redis;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFromRedis()
        {
            var model = RedisProvider.Instance.GetAllData<List<Person>>("People");
            return Ok(model);
        }
    }
}
