using System;
using System.Collections.Generic;
using System.Text;

namespace Redis
{
    public class Person
    {
        public Person(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
