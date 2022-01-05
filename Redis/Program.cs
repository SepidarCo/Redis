﻿using Redis;
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

           // RedisProvider.Instance.SetCacheData(people, "People");

            RedisProvider.Instance.RemoveAllData<Person>("People");

            //var model = RedisProvider.Instance.GetAllData<List<Person>>("People");

            Console.WriteLine("done");

            Console.ReadKey();

        }



    }
}
