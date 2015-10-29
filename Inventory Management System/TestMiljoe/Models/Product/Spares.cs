using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Product
{
    public class SparePart : Product
    {
        public SparePart(int amount, Label label, Price price, Location location)
            : base(amount, label, price, location) { }

    }
}