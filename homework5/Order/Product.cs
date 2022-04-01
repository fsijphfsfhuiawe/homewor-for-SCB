using System;
using System.Collections.Generic;
using System.Text;

namespace Order
{
    public class Product
    {
        public string ProcuctName { get; set; }
        public int UnitPrice { get; set; }
        public Product() { ProcuctName = "X"; UnitPrice = 0; }
        public Product(string pn, int up)
        {
            this.ProcuctName = pn;
            this.UnitPrice = up;
        }
    }
}
