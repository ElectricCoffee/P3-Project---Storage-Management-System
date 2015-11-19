using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventory_Management_System.MySql;

namespace Inventory_Management_System.Tests
{
    [TestClass]
    public class MySqlTest
    {

        [TestMethod]
        public void SendStringTest()
        {
            string text = String.Format("INSERT INTO {0}(UserName) VALUE('Morten')", MySqlCommunication.EmployeeTable); //her bliver der oprettet en ny bruger
            Assert.AreEqual(text, MySqlCommunication.SendString(text));
        }

        [TestMethod]
        public void GetStringTest()
        {
            string text = String.Format("SELECT Username FROM {0} WHERE UserName = 'Morten'", MySqlCommunication.EmployeeTable);
            Assert.AreEqual("Morten", MySqlCommunication.GetString(text));
        }

        [TestMethod]
        public void CreatUserTest()
        {
            MySqlCommunication.CreateUser("mortenm12", "password", "Test", "Morten Rasmussen"); //her bliver der oprette in ny bruger
        }

        [TestMethod]
        public void GetHashedPasswordTest()
        {
            Assert.AreEqual("5feee964e3c8347b06cb028fadcd1e15688db84f", MySqlCommunication.GetHashedPassword("mortenm12"));
        }

        [TestMethod]
        public void SelectTest()
        {
            Assert.AreEqual("Morten", MySqlCommunication.Select(MySqlCommunication.EmployeeTable, "UserName", "UserName", "Morten"));
        }

        [TestMethod]
        public void InsertTest()
        {
            MySqlCommunication.Insert(MySqlCommunication.EmployeeTable, new System.Collections.Generic.List<string> { "UserName", "Role" }, new System.Collections.Generic.List<string> { "mortenm123", "Test" }); //her bliver der oprette en ny bruger
        }

        [TestMethod]
        public void UpdateTest()
        {
            MySqlCommunication.Update(MySqlCommunication.EmployeeTable, new System.Collections.Generic.List<string> { "Name" }, new System.Collections.Generic.List<string> { "Morten Meyer Rasmussen" }, "UserName", "mortenm123");
        }

        [TestMethod]
        public void GetListTest()
        {
            string text = String.Format("SELECT Name FROM {0} WHERE Name = 'Morten Rasmussen'", MySqlCommunication.EmployeeTable);
            Assert.AreEqual(1, MySqlCommunication.GetList(text, 1).Count);
        }

        [TestMethod]
        public void FilterListTest()
        {
            Assert.AreEqual(1, MySqlCommunication.FilterList(MySqlCommunication.EmployeeTable, "Name", "Morten Rasmussen", 1).Count);
        }

        [TestMethod]
        public void SelectAllTest()
        {
            Assert.AreEqual(7, MySqlCommunication.SelectAll(MySqlCommunication.RoleTable, 1).Count);
        }

        [TestMethod]
        public void GetColumnNameTest()
        {
            Assert.AreEqual(5, MySqlCommunication.GetColumnName(MySqlCommunication.EmployeeTable).Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            MySqlCommunication.Delete(MySqlCommunication.EmployeeTable, "UserName", "Morten");
            MySqlCommunication.Delete(MySqlCommunication.EmployeeTable, "UserName", "mortenm12"); //oprydning
            MySqlCommunication.Delete(MySqlCommunication.EmployeeTable, "UserName", "mortenm123"); //oprydning
        }
    }

}
