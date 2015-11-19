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
            string text = String.Format("INSERT INTO {0}(Username) VALUE('Morten')", MySqlCommunication.EmployeeTable); //her bliver der oprettet en ny bruger
            Assert.AreEqual(text, MySqlCommunication.SendString(text));
        }

        [TestMethod]
        public void GetStringTest()
        {
            string text = String.Format("SELECT Username FROM {0} WHERE Username = Morten", MySqlCommunication.EmployeeTable);
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
            Assert.AreEqual("f2779e9a39e8c37c6bd1d1571a2cb553a03ab252", MySqlCommunication.GetHashedPassword("mortenm12"));
        }

        [TestMethod]
        public void SelectTest()
        {
            Assert.AreEqual("Morten", MySqlCommunication.Select(MySqlCommunication.EmployeeTable, "Username", "Username", "Morten"));
        }

        [TestMethod]
        public void InsertTest()
        {
            MySqlCommunication.Insert(MySqlCommunication.EmployeeTable, new System.Collections.Generic.List<string> { "Username", "Role" }, new System.Collections.Generic.List<string> { "mortenm123", "Test" }); //her bliver der oprette en ny bruger
        }

        [TestMethod]
        public void UpdateTest()
        {
            MySqlCommunication.Update(MySqlCommunication.EmployeeTable, new System.Collections.Generic.List<string> { "Name" }, new System.Collections.Generic.List<string> { "Morten Meyer Rasmussen" }, "Username", "mortenm123");
        }

        [TestMethod]
        public void GetListTest()
        {
            string text = String.Format("SELECT FROM {0} WHERE Name = Morten", MySqlCommunication.EmployeeTable);
            Assert.AreEqual(2, MySqlCommunication.GetList(text, 1).Count);
        }

        [TestMethod]
        public void FilterListTest()
        {
            Assert.AreEqual(2, MySqlCommunication.FilterList(MySqlCommunication.EmployeeTable, "Name", "Morten", 1));
        }

        [TestMethod]
        public void SelectAllTest()
        {
            Assert.AreEqual(7, MySqlCommunication.SelectAll(MySqlCommunication.RoleTable, 1));
        }

        [TestMethod]
        public void GetColumnNameTest()
        {
            Assert.AreEqual(5, MySqlCommunication.GetColumnName(MySqlCommunication.EmployeeTable));
        }

        [TestMethod]
        public void DeleteTest()
        {
            MySqlCommunication.Delete(MySqlCommunication.EmployeeTable, "Username", "Morten");
            MySqlCommunication.Delete(MySqlCommunication.EmployeeTable, "Username", "mortenm12"); //oprydning
            MySqlCommunication.Delete(MySqlCommunication.EmployeeTable, "Username", "mortenm123"); //oprydning
        }
    }

}
