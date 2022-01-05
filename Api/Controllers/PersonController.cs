using Microsoft.AspNetCore.Mvc;
using Redis;
using System.Collections.Generic;

namespace Api.Controllers
{
   
    public class PersonController : GeneralController
    {
        [HttpGet]
        public IActionResult GetFromRedis()
        {
            var model = RedisProvider.Instance.GetAllData<List<Person>>("People");
            return Ok(model);
        }

    }
}
