using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventory_Management_System.MySql;

namespace Inventory_Management_System.Tests
{
    [TestClass]
    public class MySqlTest
    {

        [TestMethod]
        public void SendSTringTest()
        {
            string text = String.Format("INSERT INTO {0}(Username) VALUE('Morten')", MySqlCommunication.EmployeeTable);
            Assert.AreEqual(text, MySqlCommunication.SendString(text));
        }

        [TestMethod]
        public void GetStringTest()
        {
            string text = String.Format("SELECT Username FROM {0} WHERE Username = Morten", MySqlCommunication.EmployeeTable);
            Assert.AreEqual("Morten", MySqlCommunication.GetString(text));
        }
    }
}
