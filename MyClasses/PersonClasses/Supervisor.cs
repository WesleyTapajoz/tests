using System.Collections.Generic;

namespace MyClasses.PersonClasses
{
    public class Supervisor : Person
    {
        public List<Employeer> Employees { get; set; }
    }
}
