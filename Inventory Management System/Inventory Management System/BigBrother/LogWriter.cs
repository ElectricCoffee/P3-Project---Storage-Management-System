using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.Models.Product;
using Inventory_Management_System.Models.EmployeeData;
using System.IO;

namespace Inventory_Management_System.BigBrother
{
    public class LogWriter
    {
        private string filepath = Directory.GetParent(Directory.GetParent(Directory.GetParent(
            Directory.GetCurrentDirectory()).ToString()).ToString()).ToString() + @"\LOG.txt";

        public LogWriter(Product p, Employee e)
        {
            WriteLogProduct(p, e);
        }
        public LogWriter(PSystem p, Employee e)
        {
            WriteLogSystem(p, e);
        }
        public LogWriter(Product p)
        {
            WriteLogProduct(p);
        }
        public LogWriter(PSystem p)
        {
            WriteLogSystem(p);
        }
        /// <summary>
        /// Write product log without employee input
        /// </summary>
        /// <param name="p">product to log</param>
        private void WriteLogProduct(Product p)
        {
            using (TextWriter w = File.CreateText(filepath))
            {
                w.WriteLine("Product created with articlenumber: " + p.ArticleNumber1);
            }
            
        }
        /// <summary>
        /// Write system log without employee input
        /// </summary>
        /// <param name="p">system to log</param>
        private void WriteLogSystem(PSystem p)
        {
            using (TextWriter w = File.CreateText(filepath))
            {
                w.WriteLine("Product created with articlenumber: " + p.ArticleNumber1);
            }
        }
        /// <summary>
        /// Write product to log with employee id
        /// </summary>
        /// <param name="p">product object</param>
        /// <param name="e">employee object</param>
        private void WriteLogProduct(Product p, Employee e)
        {
            using (TextWriter w = File.CreateText(filepath))
            {
                w.WriteLine("Product created with articlenumber: " + p.ArticleNumber1 + " ; Created by user: " + e.Username);
            }
        }
        /// <summary>
        /// write system to log with employee id
        /// </summary>
        /// <param name="p">system object</param>
        /// <param name="e">employee object</param>
        private void WriteLogSystem(PSystem p, Employee e)
        {
            using (TextWriter w = File.CreateText(filepath))
            {
                w.WriteLine("Product created with articlenumber: " + p.ArticleNumber1 + " ; Created by user: " + e.Username);
            }
        }
        //private void WriteLogSparepart()
        //{
        //    string tempString = p.ToString(SparePart p);

        //    string filepath = Directory.GetParent(Directory.GetParent(Directory.GetParent(
        //    Directory.GetCurrentDirectory()).ToString()).ToString()).ToString() + @"\LOG.txt";

        //    File.WriteAllText(filepath, tempString);
        //}
    }
}