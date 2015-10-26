using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.Utils;
namespace Inventory_Management_System.Models.Product
{
    public abstract class Product
    {
        public Product(int articlenumber1, string name, string worldlocation, string inventorylocation,
            int amount, int aprice, string tags, string catagory, int salesprice) 
        {
            if (Security.AnyNullOrEmpty(articlenumber1, name, worldlocation,
                inventorylocation, amount, tags, catagory, aprice, salesprice))
            {
                throw new ArgumentNullException("Du det dårligste menneske jeg kender.");
            }
            ArticleNumber1 = articlenumber1;
            Name = name;
            Worldlocation = worldlocation;
            InventoryLocation = inventorylocation;
            Amount = amount;
            APrice = aprice;
            Tags = tags;
            Catagory = catagory;
            SalesPrice = salesprice;
        }

        public int ArticleNumber1 { get; set; }
        public int ArticleNumber2 { get; set; }
        public string Name { get; set; }
        public string Worldlocation { get; set; }
        public string InventoryLocation { get; set; }
        public int Amount { get; set; }
        public int APrice { get; set; }
        public string Tags { get; set; }
        public string Catagory { get; set; }
        public int SalesPrice { get; set; }
    }
}