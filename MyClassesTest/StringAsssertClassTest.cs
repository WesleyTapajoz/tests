using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace MyClassesTest
{
    [TestClass]
    public class StringAsssertClassTest
    {
        [TestMethod]
        [Owner("Wesley")]
        public void ContainsTest()
        {
            string str1 = "Wesley Tapajoz";
            string str2 = "Tapajoz";
            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        [Owner("Wesley")]
        public void StartWithTest()
        {
            string str1 = "Todos Caixa Alta";
            string str2 = "Todos Caixa";
            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        [Owner("Wesley")]
        public void IsAllLowerCaseTest()
        {
           var reg = new Regex(@"^([^A-Z])+$");
 
            StringAssert.Matches("todos caixa", reg);
        }

        [TestMethod]
        [Owner("Wesley")]
        public void IsNotAllLowerCaseTest()
        {
            var reg = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("Todos Caixa", reg);
        }
    }
}
