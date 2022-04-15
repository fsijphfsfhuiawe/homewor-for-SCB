using System;
using System.Collections.Generic;
using System.Text;

namespace Order
{
    public class OrderService
    {
        List<Order> Orders = new List<Order>();
        public void Sort()
        {
            Orders.Sort((o1, o2) => o1.Id - o2.Id);
        }
        public void SortByMoney()
        {
            Orders.Sort((o1, o2) => o1.OrderDetails.SalesAmount);
        }
        public void Sort( Comparer<Order> comparer )
        {
            Orders.Sort(comparer);
        }
        //增加和删除订单都仅返回表示“操作是否成功”bool值
        public bool AddOrder(Order xorder)
        {
            Orders.Add(xorder);
            return xorder!=null;
        }
        public bool DeleteOrder(Order xorder)
        {
            if (Orders.Contains(xorder)) Orders.Remove(xorder);
            return xorder != null;
        }
        public bool ChangeOrder(Order xorder, Order newOrder)
        {
            if (newOrder == null) throw new Exception($"Can't change the order this way!");
            if (Orders.Contains(xorder)) { xorder = newOrder; return true; }
            else throw new Exception($"Can't find the corresponding order to change!");
        }
        public Order FindOrder(Order order)
        {
            if (order == null) throw new Exception($"Wrong Input");
            if (Orders.Contains(order)) return order;
            throw new Exception($"There is no such order");
        }
        public Order FindOrder(int id)
        {
            foreach (Order order in Orders)
            {
                if (order.Id == id) { return order; }
            }
            throw new Exception($"There is no such order whose id is " + id);
        }
        public Order FindOrder(string name)
        {
            foreach (Order order in Orders)
            {
                if (order.OrderDetails.ClientName==name) { return order; }
            }
            throw new Exception($"There is no such order whose client name is " + name);
        }
    }
}
