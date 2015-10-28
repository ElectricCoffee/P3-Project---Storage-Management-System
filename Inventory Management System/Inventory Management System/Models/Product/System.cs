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

    public enum TransitType { Inbound, Outbound, None }

    class System : Product
    {
        public System(Id id, Location location, int amount, Price price, string acquisitor,
            Status status, string documentDirectory, string documentName,
            string specsheetDirectory, string specsheetName, string imageDirectory, string imageName)
            : base(amount, id, price, location)
        {
            if (Security.AnyNullOrEmpty(id.ArticleNumber1, id.SerialNumber, id.Name, id.Tags,
                id.Catagory, id.Model, id.ProductionYear, location.WorldLocation, location.InventoryLocation,
                amount, price.AcquisitionPrice, price.SalesPrice, status.Transit, status.InventoryStatus,
                status.SalesStatus, acquisitor))
            {
                throw new ArgumentNullException("Du det dårligste menneske jeg kender.");
            }

            ArticleNumber2 = id.ArticleNumber2;
            SerialNumber = id.SerialNumber;
            Transit = status.Transit;
            InventoryStatus = status.InventoryStatus;
            SalesStatus = status.SalesStatus;
            Model = id.Model;
            ProductionYear = id.ProductionYear;
            Acquisitor = acquisitor;


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



        public int ArticleNumber2 { get; set; }
        public int SerialNumber { get; set; }
        public TransitType Transit { get; set; }
        public string InventoryStatus { get; set; }
        public string SalesStatus { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string Acquisitor { get; set; }
        public List<SparePart> Parts { get; set; }
        public Bitmap Images { get; set; }
        public List<string> SpecSheet { get; set; }
        public List<string> FDocuments { get; set; }

        #region Helper classes
        public class Id : Label
        {
            public int ArticleNumber2 { get; set; }
            public int SerialNumber { get; set; }
            public string Model { get; set; }
            public int ProductionYear { get; set; }
        }

        public class Status
        {
            public TransitType Transit { get; set; }
            public string InventoryStatus { get; set; }
            public string SalesStatus { get; set; }
        }

        #endregion
    }
}
