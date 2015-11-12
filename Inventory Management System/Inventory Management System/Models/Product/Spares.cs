using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Product
{
    public class SparePart : Product
    {
        public SparePart(Label label, Price price, Location location)
            : base(label, price, location) { }

#if Debug
#warning - Skal rettes
#endif
    }
}