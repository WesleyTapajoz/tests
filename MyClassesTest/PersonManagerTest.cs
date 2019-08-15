using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        [Owner("Wesley")]
        public void CreatePerson_OfTeEmployeeTest()
        {
            var PerMgr = new PersonManager();
            Person per;
            per = PerMgr.CreatePerson("Wesley", "Tapajoz", false);
            Assert.IsInstanceOfType(per, typeof(Employeer));
        }

        [Owner("Wesley")]
        [TestMethod]
        public void DoEmployeeExistTest()
        {
            var super = new Supervisor
            {
                Employees = new List<Employeer>(),
            };

            super.Employees.Add(new Employeer()
            {
                FirstName = "Wesley",
                LastName = "Tapajoz"
            });

            Assert.IsTrue(super.Employees.Count > 0);
        }
    }
}
