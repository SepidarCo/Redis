using Microsoft.AspNetCore.Mvc;
using Redis;
using System.Collections.Generic;

namespace Api.Controllers
{

    public class PersonController : GeneralController
    {
        [HttpGet]
        public IActionResult GetPersonFromRedis()
        {
            var model = RedisProvider.Instance.GetAllData<List<Person>>("People");
            return Ok(model);
        }

        //[HttpGet]
        //public IActionResult AddToRedis()
        //{
        //    List<Person> people = new List<Person>();

        //    for (int i = 0; i < 6000; i++)
        //    {
        //        people.Add(new Person(i, "ali"));
        //    }

        //    RedisProvider.Instance.SetCacheData(people, "People");

        //    return Ok("done");
        //}
    }
}
