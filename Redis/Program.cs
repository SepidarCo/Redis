using Redis;
using System;
using System.Collections.Generic;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < 6000; i++)
            {
                people.Add(new Person(i, "ali"));
            }

            RedisProvider.Instance.SetCacheData(people, "People");

            //  RedisProvider.Instance.RemoveAllData<Person>("People");

            //var model = RedisProvider.Instance.GetAllData<List<Person>>("People");

            Console.WriteLine("done");

            Console.ReadKey();

        }



    }
}
