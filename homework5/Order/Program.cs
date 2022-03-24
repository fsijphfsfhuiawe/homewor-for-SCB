using System;
using System.Collections.Generic;

namespace Order
{
    //“总”订单（区别于单个订单）
    public class Order
    {
        //对应的单个订单详情
        public OrderDetails OrderDetails;
        //订单号
        public int OrderNumber { get; set; }

        //构造函数
        public Order(OrderDetails orderDetails)
        {
            this.OrderDetails = orderDetails;
            Random r = new Random();
            OrderNumber = r.Next(1000);
        }

        //判断订单及订单明细是否相同
        public override bool Equals(Object obj)
        {
            Order order = obj as Order;
            return order != null && order.OrderDetails.Equals(OrderDetails);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(OrderDetails, OrderNumber);
        }

        public override string ToString()
        {
            Console.WriteLine("Order Number: {0}", OrderNumber);
            this.OrderDetails.ToString();
            return "Done";
        }

    }

    //订单的详情
    public class OrderDetails
        //包含该订单的商品类型列表，
        //某种商品的订购数量，该单个订单的交易总金额
    {
        string ClientName;
        public Client Client;
        List<Product> ProductList;
        int[] ProductNumber;
        public int SalesAmount;

        //构造函数
        public OrderDetails(Client client, List<Product> products, int[] productNumber)
        {
            this.ClientName = client.ClientName;
            this.Client = client;
            this.ProductList = products;
            this.ProductNumber = productNumber;
            foreach(Product product in products)
            {
                SalesAmount = product.UnitPrice * productNumber[products.IndexOf(product)];
            }
        }

        //打印订单详情
        public override string ToString()
        {
            Console.WriteLine("Client: {0}   Total Payment:{1}", ClientName, SalesAmount);
            Console.WriteLine("Product Name   Total Number");
            foreach (Product product in ProductList)
            {
                Console.WriteLine("{0}--------{1}",product.ProcuctName,ProductNumber[ProductList.IndexOf(product)]);
            }
            return "Done";
        }

        //判断订单明细是否相同
        public override bool Equals(Object obj)
        {
            OrderDetails orderDetails = obj as OrderDetails;
            return orderDetails != null && orderDetails.ClientName == ClientName
                && orderDetails.ProductList == ProductList;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ClientName, ProductList, ProductNumber, SalesAmount);
        }
    }

    public class OrderService
        //单独抽出业务逻辑，增删改查
    {
        //包含所有业务订单
        public List<Order> list = new List<Order>();

        //对订单列表进行排序
        //按订单号从高到低进行默认排序（排序结果以订单号的列表呈现
        public List<int> Sort() {
            List<int> vs = new List<int>();
            foreach(Order order in list)
            {
                vs.Add(order.OrderNumber);
            }
            vs.Sort();
            return vs;
        }
        //按照订单总金额进行查询、排序并返回
        public List<Order> Sort(List<Order> orders)
        {
            int[] vs = new int[100000];
            List<Order> newOrders = new List<Order>();
            foreach (Order order in list)
            {
                vs[orders.IndexOf(order)] = order.OrderDetails.SalesAmount;
            }
            Array.Sort(vs);
            Array.Reverse(vs);
            for (int i = 0; i < vs.Length; i++)
            {
                foreach(Order order in orders)
                {
                    if(order.OrderDetails.SalesAmount == i)
                    {
                        newOrders.Add(order);
                    }
                }
            }
            return newOrders;
        }
        
        //添加订单
        public List<Order> AddOrder(Order xorder)
        {
            try
            {
                bool flag = false;
                foreach (Order order in list)
                {
                    //仅当有相等订单时，flag变为真
                    if (order.Equals(xorder)) flag = true;
                }
                if (flag == false) list.Add(xorder);
                return this.list;
            }
            catch (Exception e)
            {
                Console.WriteLine("The 'Add' operation fails!");
                Console.WriteLine(e);
                return this.list;
            }
        }

        //删除订单
        public List<Order> DeleteOrder(Order xorder)
        {
            try
            {
                bool flag = false;
                foreach (Order order in list)
                {
                    //仅当有相等订单时，flag变为真
                    if (order.Equals(xorder)) flag = true;
                }
                if (flag == false) list.Remove(xorder);
                    return this.list;
            }
            catch (Exception e)
            {
                Console.WriteLine("The 'Delete' operation fails!");
                Console.WriteLine(e);
                return this.list;
            }
        }

        //修改订单
        public List<Order> ChangeOrder(Order xorder, Order newOrder)
        {
            try
            {
                bool flag = false;
                foreach (Order order in list)
                {
                    //仅当有相等订单时，flag变为真
                    if (order.Equals(xorder)) flag = true;
                }
                if (flag == false) xorder = newOrder;
                return this.list;
            }
            catch (Exception e)
            {
                Console.WriteLine("The 'Chage' operation fails!");
                Console.WriteLine(e);
                return this.list;
            }
        }

        //实现各种查询功能，查询结果按照订单总金额排序返回
        //按照订单号，客户等进行查询
        public void SelectOrder(Order xorder)
        {
            list = Sort(list);
            bool flag = true;
            foreach(Order order in list)
            {
                if (order.OrderNumber == xorder.OrderNumber)
                {
                    order.ToString();
                    flag = false;
                }
            }
            if (flag) Console.WriteLine("There's No such order!");
        }
        //使用客户作为参数进行查询
        public void SelectOrder(Client client)
        {
            list = Sort(list);
            bool flag = true;
            foreach(Order order in list) {
                if (order.OrderDetails.Client.ClientName == client.ClientName){order.ToString();flag = false;}
            }
            if (flag) Console.WriteLine("There's No such order!");
        }
    }

    public class Product
    {
        //包含产品名称，产品单价
        public string ProcuctName { get; set; }
        public int UnitPrice { get; set; }
        public Product() { ProcuctName = "X"; UnitPrice = 0; }
        public Product(string pn, int up)
        {
            this.ProcuctName = pn;
            this.UnitPrice = up;
        }
    }

    public class Client
    {
        //包含用户名称，该用户所持有的订单列表
        public string ClientName;
        public List<Product> products = new List<Product>();
        public int[] productNumber = new int[100000];

        public Client(string n)
        {
            this.ClientName = n;
        }

        /*//返回该用户所持有的订单列表的订单号
        public int[] GetOrders()
        {
            try
            {
                int[] vs = { 0 };
                foreach (Order order in orders)
                {
                    vs[orders.IndexOf(order)] = order.OrderNumber;
                }
                return vs;
            }
            catch (Exception e)
            {
                Console.WriteLine("This Client doesn't maintain any orders.");
                return null;
            }
        }*/

        //用户可以决定要买什么商品
        public void makeProductList(Product p, int i)
        {
            products.Add(p);
            productNumber[products.IndexOf(p)] = i;
        }
    }

     class Program
    {
        static void Main(string[] args)
        {
            //客户们
            Client A = new Client("A");
            Client B = new Client("B");
            //产品们
            Product P1 = new Product("p1", 5);
            Product P2 = new Product("p2", 10);
            Product P3 = new Product("p1", 8);
            Product P4 = new Product("p2", 15);
            //客户决定要买什么
            A.makeProductList(P1, 100);
            A.makeProductList(P3, 80);
            B.makeProductList(P1, 120);
            B.makeProductList(P4, 60);
            //客户发起购买请求
            OrderDetails orderD1 = new OrderDetails(A, A.products, A.productNumber);
            OrderDetails orderD2 = new OrderDetails(B, B.products, B.productNumber);
            //生成订单并录入系统
            Order order1 = new Order(orderD1);
            Order order2 = new Order(orderD2);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            //查询订单
            Console.WriteLine("Select the orders:");
            os.SelectOrder(A);
            Console.WriteLine("  ");
            os.SelectOrder(order2);
            Console.WriteLine("  ");
            Console.WriteLine("  ");

            //删除订单
            Console.WriteLine("Delete one order:");
            os.DeleteOrder(order1);
            Console.WriteLine("  ");


            //再次查询
            Console.WriteLine("Reselect the orders:");
            os.SelectOrder(order1);
            Console.WriteLine("  ");
            os.SelectOrder(A);
        }
    }
}
