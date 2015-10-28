using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace Inventory_Management_System.Models.Product
{
    public static class TEMPProductLoader
    {
        public List<Product> NOGET { get; private set; }

        public TEMPProductLoader(Product p)
        {
            LoadListOfProducts();
        }
        private void LoadShit(string fileName)
        {
            string filepath = Directory.GetParent(Directory.GetParent(Directory.GetParent(
            Directory.GetCurrentDirectory()).ToString()).ToString()).ToString() + @"\" + fileName;

            var jsondata = JsonConvert.DeserializeObject<List<Product>>(filepath);

            foreach (var js in jsondata)
            {
                NOGET.Add(js);
            }
        }

        private void Writeshit(string fileName)
        {
            string json = JsonConvert.SerializeObject(NOGET.ToArray());

            string filepath = Directory.GetParent(Directory.GetParent(Directory.GetParent(
            Directory.GetCurrentDirectory()).ToString()).ToString()).ToString() + @"\" + fileName + ".txt";

            File.WriteAllText(filepath, json);
        }

        private void WriteToList(Product p) 
        {
            foreach (Product pr in NOGET)
            {
                if (p.ArticleNumber1 == pr.ArticleNumber1)
                {
                    Console.WriteLine("Findes allerede i systemet spasser :3");
                }
                else 
                {
                    NOGET.Add(p);
                }
            }
        }
        public void skrivNOGETtilFil(Product p)
        {
            WriteToList(p);
            Writeshit("Products");
        }
        private void LoadListOfProducts()
        {
            if (NOGET != null)
            {
                LoadShit("Products");
            }
            else Console.WriteLine("Noget er galt - Kontakt Mr. Lepka ved uundgåeligt vrøvl - 10hi f9z vrøvlehoved :3");
        }
    }
}