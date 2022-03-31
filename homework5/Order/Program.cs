using System;
using System.Collections.Generic;

namespace Order
{
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
            OrderDetails orderD1 = new OrderDetails(A);
            OrderDetails orderD2 = new OrderDetails(B);
            //生成订单并录入系统
            Order order1 = new Order(orderD1);
            Order order2 = new Order(orderD2);
            OrderService os = new OrderService();
            if (os.AddOrder(order1)) Console.WriteLine(order1.ToString());
            if (os.AddOrder(order2)) Console.WriteLine(order2.ToString());
            //查询订单
            Console.WriteLine("Sort the orders:");
            Console.WriteLine("  ");
            os.Sort();
            //删除订单
            Console.WriteLine("Delete one order:");
            os.DeleteOrder(order1);
            Console.WriteLine("  ");
            //再次查询
            Console.WriteLine("Reselect the orders:");
            os.Sort();
            Console.WriteLine("  ");
            os.Sort();
        }
    }
}
