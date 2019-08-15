using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        //    [TestMethod]
        //    [Owner("Wesley")]
        //    public void AreCollectionEqualFailBecauseNoComparerTest()
        //    {
        //        var PerMgr = new PersonManager();
        //        var peopleActual = new List<Person>();
        //        var peopleExpected = new List<Person>
        //        {
        //            new Person() { FirstName = "Wesley", LastName = "Tapajoz" },
        //            new Person() { FirstName = "Vinicius", LastName = "Tapajoz" },
        //            new Person() { FirstName = "Julia", LastName = "Tapajoz" }
        //        };
        //        //You shall not pass!
        //        peopleActual = PerMgr.GetPeople();

        //        CollectionAssert.AreEqual(peopleExpected, peopleActual);
        //    }

        [TestMethod]
        [Owner("Wesley")]
        public void AreCollectionEqualComparerTest()
        {
            var PerMgr = new PersonManager();
            var peopleActual = new List<Person>();
            var peopleExpected = new List<Person>
            {
                new Person() { FirstName = "Wesley", LastName = "Tapajoz" },
                new Person() { FirstName = "Vinicius", LastName = "Tapajoz" },
                new Person() { FirstName = "Julia", LastName = "Tapajoz" }
            };

            //You shall not pass!
            peopleActual = PerMgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual, Comparer<Person>.Create((x, y) => x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1));
        }

        [TestMethod]
        [Owner("Wesley")]
        public void AreCollectionEquivalentTest()
        {
            var PerMgr = new PersonManager();
            var peopleActual = new List<Person>();


            //You shall not pass!
            peopleActual = PerMgr.GetSupervisor();

            var peopleExpected = new List<Person>
            {
                 peopleActual[1],
                 peopleActual[2],
                 peopleActual[0],
            };


            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("Wesley")]
        public void IsCollectionOfTypeTest()
        {
            var PerMgr = new PersonManager();
            var peopleActual = new List<Person>();

            //You shall not pass!
            peopleActual = PerMgr.GetSupervisor();

            var peopleExpected = new List<Person>
            {
                 peopleActual[1],
                 peopleActual[2],
                 peopleActual[0],
            };


            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }
    }
}
