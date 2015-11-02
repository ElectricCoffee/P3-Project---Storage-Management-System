//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.IO;
//using Newtonsoft.Json;

//namespace Inventory_Management_System.Models.Product
//{
//    public static class TEMPProductLoader
//    {
//        public static List<Product> ListOfProducts { get; private set; }

//        public static TEMPProductLoader(Product p)
//        {
//            LoadListOfProducts();
//        }

//        private static void LoadFileIntoList(string fileName)
//        {
//            string filepath = Directory.GetParent(Directory.GetParent(Directory.GetParent(
//            Directory.GetCurrentDirectory()).ToString()).ToString()).ToString() + @"\" + fileName;

//            var jsondata = JsonConvert.DeserializeObject<List<Product>>(filepath);

//            foreach (var js in jsondata)
//                ListOfProducts.Add(js);
//        }

//        private static void WriteObjectToFile(string fileName)
//        {
//            string json = JsonConvert.SerializeObject(ListOfProducts.ToArray());

//            string filepath = Directory.GetParent(Directory.GetParent(Directory.GetParent(
//            Directory.GetCurrentDirectory()).ToString()).ToString()).ToString() + @"\" + fileName + ".txt";

//            File.WriteAllText(filepath, json);
//        }

//        private static void WriteProductToList(Product p) 
//        {
//            foreach (Product pr in ListOfProducts)
//            {
//                if (p.ArticleNumber1 == pr.ArticleNumber1)
//                {
//                    Console.WriteLine("Findes allerede i systemet spasser :3");
//                }
//                else 
//                {
//                    ListOfProducts.Add(p);
//                }
//            }
//        }
//        public static void SkribListentilFil(Product p)
//        {
//            WriteProductToList(p);
//            WriteObjectToFile("Products");
//        }
//        private static void LoadListOfProducts()
//        {
//            if (ListOfProducts != null)
//            {
//                LoadFileIntoList("Products");
//            }
//            else Console.WriteLine("Noget er galt - Kontakt Mr. Lepka ved uundgåeligt vrøvl - 10hi f9z vrøvlehoved :3");
//        }
//    }
//}