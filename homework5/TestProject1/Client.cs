using System;
using System.Collections.Generic;
using System.Text;

namespace Order
{
    public class Client
    {
        public string ClientName;
        public List<Product> Products = new List<Product>();
        public int[] ProductNumber = new int[100000];
        public Client(string n)
        {
            this.ClientName = n;
        }
        public List<Product> makeProductList(Product p, int i)
        {
            Products.Add(p);
            ProductNumber[Products.IndexOf(p)] = i;
            return Products;
        }
    }
}
