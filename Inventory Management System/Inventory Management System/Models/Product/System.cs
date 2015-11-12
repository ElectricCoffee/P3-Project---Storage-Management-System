using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_System.Utils;
using System.Drawing;
using System.IO;

namespace Inventory_Management_System.Models.Product
{
    public class PSystem : Product
    {
        public PSystem(Id id, Location location, Price price,
            Status status, Directories directories)
            : base(id, price, location)
        {
            if (Security.AnyNullOrEmpty(id.ArticleNumber1, id.SerialNumber, id.Name, id.Tags,
                id.Catagory, id.Model, id.ProductionYear, location.WorldLocation, location.InventoryLocation,
                location.Amount, price.AcquisitionPrice, price.SalesPrice, location.Transit, status.InventoryStatus,
                status.SalesStatus, id.Acquisitor))
            {
                throw new ArgumentNullException("Du det dårligste menneske jeg kender.");
            }

            ArticleNumber2 = id.ArticleNumber2;
            SerialNumber = id.SerialNumber;
            InventoryStatus = status.InventoryStatus;
            SalesStatus = status.SalesStatus;
            Model = id.Model;
            ProductionYear = id.ProductionYear;
            Acquisitor = id.Acquisitor;


#if DEBUG
#warning - Skal lige kvalitet checkes, da jeg ikke ved om dette er okay.
            if (imageName != null && imageDirectory != null)
            {
                Images = (Bitmap)Image.FromFile(imageDirectory + @"\" + imageName);
            }
            if (specsheetDirectory != null && specsheetName != null)
            {
                loadspecsheet(specsheetDirectory, specsheetName);
            }
            if (documentDirectory != null && documentName != null)
            {
                loadDocument(documentDirectory, documentName);
            }
#endif
        }


        private void loadDocument(string MainDirectory, string filename)
        {
            string filsti = MainDirectory + @"\" + filename + ".txt";
            foreach (var s in filsti)
            {
                FDocuments.Add(s.ToString());
            }
        }

        private void loadspecsheet(string MainDirectory, string filename)
        {
            string filsti = MainDirectory + @"\" + filename + ".txt";
            foreach (var s in filsti)
            {
                SpecSheet.Add(s.ToString());
            }
        }

        public string ArticleNumber2 { get; set; }
        public string SerialNumber { get; set; }
        public string InventoryStatus { get; set; }
        public string SalesStatus { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public List<SparePart> Parts { get; set; }
        public Bitmap Images { get; set; }
        public List<string> SpecSheet { get; set; }
        public List<string> FDocuments { get; set; }
        public string documentDirectory { get; set; }
        public string documentName { get; set; }
        public string specsheetDirectory { get; set; }
        public string specsheetName { get; set; }
        public string imageDirectory { get; set; }
        public string imageName { get; set; }

        public override string ToString()
        {
            if (ArticleNumber2 != null)
            {
                return ArticleNumber1 + ArticleNumber2 + SerialNumber + InventoryStatus + SalesStatus + Model + ProductionYear;
            }

            return ArticleNumber2 + SerialNumber + InventoryStatus + SalesStatus + Model + ProductionYear;
        }

    }
    #region Helper classes
    public class Id : Label
    {
        public string ArticleNumber2 { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
    }

    public class Status
    {
        public string InventoryStatus { get; set; }
        public string SalesStatus { get; set; }
    }

    public class Directories
    {
        public string documentDirectory { get; set; }
        public string documentName { get; set; }
        public string specsheetDirectory { get; set; }
        public string specsheetName { get; set; }
        public string imageDirectory { get; set; }
        public string imageName { get; set; }
    }
    #endregion
}