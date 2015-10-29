using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace Inventory_Management_System.Models.Product
{
    public class TEMPProductLoader
    {
        public List<Product> NOGET { get; set; }

        public void LoadShit(string fileName) 
        {
            string filepath = Directory.GetParent(Directory.GetParent(Directory.GetParent(
            Directory.GetCurrentDirectory()).ToString()).ToString()).ToString() + @"\" + fileName;
            
            var jsondata = JsonConvert.DeserializeObject<List<Product>>(filepath);

            foreach (var js in jsondata)
            {
                NOGET.Add(js);
            }
        }

        public void Writeshit(string fileName, List<Product> normList)
        {
            string filepath = Directory.GetParent(Directory.GetParent(Directory.GetParent(
            Directory.GetCurrentDirectory()).ToString()).ToString()).ToString() + @"\" + fileName;


        }
    

    }
    
}