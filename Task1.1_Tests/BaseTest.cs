using NUnit.Framework;
using Task1_Logger;
using Task2_InventoryManagement;

namespace Task1._1_Tests
{
    public abstract class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            //Debug Test Product Manager Project
            ProductManager productManager = new ProductManager();

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
