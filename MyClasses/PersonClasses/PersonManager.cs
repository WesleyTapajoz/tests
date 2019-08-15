using System.Collections.Generic;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;
            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                    ret = new Supervisor();
                else
                    ret = new Employeer();

                ret.FirstName = first;
                ret.LastName = last;

            }
            return ret;
        }

        public List<Person> GetPeople()
        {
            var people = new List<Person>
            {
                new Person() { FirstName = "Wesley", LastName = "Tapajoz" },
                new Person() { FirstName = "Vinicius", LastName = "Tapajoz" },
                new Person() { FirstName = "Julia", LastName = "Tapajoz" }
            };

            return people;
        }

        public List<Person> GetSupervisor()
        {
            var people = new List<Person>
            {
                CreatePerson("Wesley", "Tapajoz", true),
                CreatePerson("Vinicius", "Tapajoz", true),
                CreatePerson("Julia", "Tapajoz", true),
            };

            return people;
        }
    }
}
