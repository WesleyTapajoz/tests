using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using MyClasses.PersonClasses;

namespace MyClassesTest
{
    [TestClass]
    public class AssertClassTest
    {

        #region AreEqual/AreNotEqual Tests

        [TestMethod]
        [Owner("Wesley")]
        public void AreEqualTest()
        {
            string str1 = "Wesley";
            string str2 = "Wesley";
            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("Wesley")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitiveTest()
        {
            string str1 = "Wesley";
            string str2 = "Vinicius";
            Assert.AreEqual(str1, str2, false);
        }

        [TestMethod]
        [Owner("Wesley")]
        public void AreNotEquaTest()
        {
            string str1 = "Wesley";
            string str2 = "Vinicius";
            Assert.AreNotEqual(str1, str2);
        }

        #endregion

        #region AreSame/AreNotSame Tests

        [TestMethod]
        [Owner("Wesley")]
        public void AreSameTest()
        {
            var x = new FileProcess();
            FileProcess y = x;
            Assert.AreSame(x, y);
        }

        //[TestMethod]
        //[Owner("Wesley")]
        //public void AreNotSameTest()
        //{
        //    var x = new FileProcess();
        //    FileProcess y = x;
        //    Assert.AreNotSame(x, y);
        //}

        #endregion

        #region IsInstaceOfType Tests
        [TestMethod]
        [Owner("Wesley")]
        public void IsInstaceOfType()
        {
            PersonManager mgr = new PersonManager();
            Person per;
            per = mgr.CreatePerson("Wesley", "Vinicius", true);
            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        [Owner("Wesley")]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;
            per = mgr.CreatePerson("", "Vinicius", true);
            Assert.IsNull(per);
        }
        #endregion
    }
}
