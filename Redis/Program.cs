using System;
using System.Collections.Generic;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            people.Add(new Person(1, "ali"));
            people.Add(new Person(2, "alireza"));
            people.Add(new Person(3, "nazanin"));
            people.Add(new Person(4, "shahrooz"));

<<<<<<< HEAD
            RedisProvider.Instance.SetCacheData(people, "People");
=======
             RedisProvider.Instance.SetCacheData(people, "People");


>>>>>>> 767e880924f652ead0cd18afd55b91a8c2ee3199

            //RedisProvider.Instance.RemoveAllData<Person>("People");

            //var model = RedisProvider.Instance.GetAllData<List<Person>>("People");

<<<<<<< HEAD
            Console.WriteLine(model);

=======
            //Console.WriteLine(model);
>>>>>>> 767e880924f652ead0cd18afd55b91a8c2ee3199
            Console.ReadKey();

        }



    }
}
