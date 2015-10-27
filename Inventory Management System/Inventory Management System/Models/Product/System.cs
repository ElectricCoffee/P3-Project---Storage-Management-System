using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_System.Utils;

namespace Inventory_Management_System.Models.Product
{

    public enum TransitType { Inbound, Outbound, None }

    class System : Product
    {
        public System(Id id, Location location, int amount, Price price, string acquisitor,
            Status status) 
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
        }

        public int ArticleNumber2 { get; set; }
        public int SerialNumber { get; set; }
        public TransitType Transit { get; set; }
        public string InventoryStatus { get; set; }
        public string SalesStatus { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string Acquisitor { get; set; }

    }
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
