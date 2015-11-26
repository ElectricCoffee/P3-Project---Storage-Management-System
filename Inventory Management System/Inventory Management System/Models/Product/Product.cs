using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.Utils;
using Inventory_Management_System.MySql;

namespace Inventory_Management_System.Models.Product
{
    public enum TransitType { Inbound, Outbound, None }

    public class Product
    {
        public Product() { }

        public Product(Label label, Price price, Location location)
        {
            /*if (Security.AnyNullOrEmpty(label.ArticleNumber1, label.Name, location.WorldLocation,
                location.InventoryLocation, location.Amount, label.Tags, label.Catagory, price.AcquisitionPrice, price.SalesPrice, label.Acquisitor))
            {
                throw new ArgumentNullException("Du det dårligste menneske jeg kender.");
            }*/
            ArticleNumber1 = label.ArticleNumber1;
            Name = label.Name;
            WorldLocation = location.WorldLocation;
            InventoryLocation = location.InventoryLocation;
            Amount = location.Amount;
            AcquisitionPrice = price.AcquisitionPrice;
            Acquisitor = label.Acquisitor;
            Tags = label.Tags;
            Catagory = label.Catagory;
            SalesPrice = price.SalesPrice;
            Transit = location.Transit;
        }

        public Product(acquisitorProduct q)
        {
            ArticleNumber1 = q.ArticleNumber1;
            Name = q.Name;
            SerialNumber = q.SerialNumber;
            Amount = q.Amount;
            AcquisitionPrice = q.AcquisitionPrice;
            Model = q.Model;
            Catagory = q.Category;
            Tags = q.Tags;
            Comment = q.Comments;

        }

        public Product(inventoryImployeeProduct q)
        {
            ArticleNumber1 = q.ArticleNumber1;
            Name = q.Name;
            SerialNumber = q.SerialNumber;
            InventoryLocation = q.InventoryLocation;
            WorldLocation = q.WorldLocation;
            Transit = q.Transit;
            InventoryStatus = q.InventoryStatus;
            Model = q.Model;
            Catagory = q.Category;
            Tags = q.Tags;
            Acquisitor = q.Acquisitor;
            SalesStatus = q.SalesStatus;
            Comment = q.Comments;
        }

        public string ArticleNumber1 { get; set; }
        public string Name { get; set; }
        public string WorldLocation { get; set; }
        public string InventoryLocation { get; set; }
        public int Amount { get; set; }
        public int AcquisitionPrice { get; set; }
        public string Tags { get; set; }
        public string Catagory { get; set; }
        public int SalesPrice { get; set; }
        public string Acquisitor { get; set; }
        public string Transit { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string Comment { get; set; }
        public string InventoryStatus { get; set; }
        public string SalesStatus { get; set; }
    }

    #region helper classes
    public class Location
    {
        public string WorldLocation { get; set; }
        public string InventoryLocation { get; set; }
        public int Amount { get; set; }
        public string Transit { get; set; }
    }

    public class Price
    {
        public int AcquisitionPrice { get; set; }
        public int SalesPrice { get; set; }
    }

    public class Label
    {
        public string ArticleNumber1 { get; set; }
        public string Tags { get; set; }
        public string Catagory { get; set; }
        public string Name { get; set; }
        public string Acquisitor { get; set; }
    }

    public class acquisitorProduct
    {
        public string ArticleNumber1 { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public int Amount { get; set; }
        public int AcquisitionPrice { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public string Tags { get; set; }
        public string Comments { get; set; }
    }

    public class inventoryImployeeProduct
    {
        public string ArticleNumber1 { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string InventoryLocation { get; set; }
        public string WorldLocation { get; set; }
        public string Transit { get; set; }
        public string InventoryStatus { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public string Tags { get; set; }
        public string Acquisitor { get; set; }
        public string SalesStatus { get; set; }
        public string Comments { get; set; }
    }
    #endregion


}