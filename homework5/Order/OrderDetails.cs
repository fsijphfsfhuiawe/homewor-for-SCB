using System;
using System.Collections.Generic;
using System.Text;

namespace Order
{
    public class OrderDetails
    {
        public string ClientName { get => Client.ClientName; }
        Client Client;
        List<Product> ProductList = new List<Product>();
        int[] ProductNumber;
        public int SalesAmount { get; }
        public OrderDetails(Client client)
        {
            this.Client = client;
            this.ProductList = client.Products;
            this.ProductNumber = client.ProductNumber;
            foreach (Product product in ProductList)
            {
                SalesAmount = product.UnitPrice * ProductNumber[ProductList.IndexOf(product)];
            }
        }
        public override string ToString()
        {
            return "Client:" + ClientName + "   Total Payment:" +SalesAmount+
                "\n" + "Product  Product Number" +
                "\n" + ProductList.ToString();
        }
    }
}
