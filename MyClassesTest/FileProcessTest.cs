using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\BadFileName.bat";
        private string _GoodFileName;
        public TestContext TestContext { get; set; }


        #region Test Initialize e Cleanup
        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName.StartsWith("FileProcessDoesExists"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Creating File: {_GoodFileName}");
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (TestContext.TestName.StartsWith("FileProcessDoesExists"))
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Deleting File: {_GoodFileName}");
                    File.Delete(_GoodFileName);
                }
            }
        }

        #endregion


        [TestMethod]
        [Owner("Wesley")]
        [DataSource("System.Data.SqlClient", @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TesteUnitario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", "FileProcessTest", DataAccessMethod.Sequential)]
        public void FileExistsTestFromDB()
        {
            var fp = new FileProcess();
            string fileName;
            bool expectedValue, causesException, fromCall;

            fileName = TestContext.DataRow["FileName"].ToString();
            expectedValue = Convert.ToBoolean(TestContext.DataRow["ExpectedValue"]);
            causesException = Convert.ToBoolean(TestContext.DataRow["CausesException"]);

            try
            {
                fromCall = fp.FileExists(fileName);
                Assert.AreEqual(expectedValue, fromCall, $"File: {fileName} has failed. METHOD: FileExistsTestFromDB");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(causesException);
            }
        }


        [TestMethod]
        [Description("Check to see f a file does exist.")]
        [Owner("Wesley")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileProcessDoesExists()
        {
            var fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing File: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);
            Assert.IsTrue(fromCall);
        }

        //[TestMethod]
        //public void FileProcessDoesExistsSimpleMessage()
        //{
        //    var fp = new FileProcess();
        //    bool fromCall;

        //    TestContext.WriteLine($"Testing File: {_GoodFileName}");
        //    fromCall = fp.FileExists(_GoodFileName);
        //    Assert.IsFalse(fromCall, "File Does NOT Exist.");
        //}

        //[TestMethod]
        //public void FileProcessDoesExistsMessageFormatting()
        //{
        //    var fp = new FileProcess();
        //    bool fromCall;

        //    TestContext.WriteLine($"Testing File: {_GoodFileName}");
        //    fromCall = fp.FileExists(_GoodFileName);
        //    Assert.IsFalse(fromCall, "File '{0}' Does NOT Exist.", _GoodFileName);
        //}

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];

            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }

        }

        private const string FILE_NAME = @"FileToDeploy.txt";
        [TestMethod]
        [Owner("Wesley")]
        [DeploymentItem(FILE_NAME)]
        public void FileNAmeDoesExistsUsingDeploymentItem()
        {
            var fp = new FileProcess();
            string fileName;
            bool fromCall;
            fileName = $@"{ TestContext.DeploymentDirectory}\{ FILE_NAME}";


            TestContext.WriteLine($"Checking File: {fileName}");
            fromCall = fp.FileExists(fileName);
            Assert.IsTrue(fromCall);

        }

        [TestMethod]
        [Timeout(3000)]
        public void SimulateTimout()
        {
            System.Threading.Thread.Sleep(1000);
        }

        [TestMethod]
        [Description("Check to see f a file does NOT exist.")]
        [Owner("Wesley")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileProcessDoesNotExists()
        {
            var fp = new FileProcess();
            bool fromCall = fp.FileExists(@"C:\SteamSetup");
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("Vinicius")]
        [Ignore]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileProcessNullOrEmpty_ThrowNewArgumentNullException()
        {
            var fp = new FileProcess();
            fp.FileExists("");
        }

        [TestMethod]
        [Owner("Vinicius")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileProcessNullOrEmpty_ThrowNewArgumentNullException_UsingCatch()
        {
            var fp = new FileProcess();
            try
            {
                fp.FileExists("");
            }
            catch (Exception)
            {

                return;
            }
            Assert.Fail("Fail expected");

        }
    }
}
