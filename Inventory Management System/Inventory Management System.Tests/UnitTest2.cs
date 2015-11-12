using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventory_Management_System.Utils;

namespace Inventory_Management_System.Tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Hash()
        {
            Assert.AreEqual("5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8", Security.Hash("password"));
        }

        [TestMethod]
        public void HashPassword()
        {
            Assert.AreEqual("f2779e9a39e8c37c6bd1d1571a2cb553a03ab252", Security.HashPassword("username", "password"));
        }

        [TestMethod]
        public void TestLoginCheck()
        {
            
        }
    }
}
