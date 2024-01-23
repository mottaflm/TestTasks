using NUnit.Framework;
using Task1_Logger;

namespace Task1._1_Tests
{
    public abstract class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            //DO ANY SETUP NEEDED FOR EACH TEST
        }

        [TearDown]
        public void Teardown() 
        { 
            //DO ANY TEARDOWN NEEDED AFTER EACH TEST
        }

        protected string[] ReadFromFile(string fileName)
        {
            var filePath = Logger.GetFolderPath() + "/" + fileName;
            return File.ReadAllLines(filePath);
        }
    }
}
