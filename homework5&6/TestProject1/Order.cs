using System;
using System.Collections.Generic;
using System.Text;
namespace Order
{
    public class Order
    {
        public OrderDetails OrderDetails;
        public int Id { get; set; }
        public Order(OrderDetails orderDetails)
        {
            this.OrderDetails = orderDetails;
            Random r = new Random();
            Id = r.Next(100000);
        }
        public override bool Equals(Object obj)
        {
            Order order = obj as Order;
            return order != null && order.Id.Equals(this.Id);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
        public override string ToString()
        {
            return "Order ID: " + Id +
                "\n" + "Order Details:" +
                "\n" + OrderDetails.ToString();
        }
    }
}