using System.Collections.Generic;
using System.Linq;
using Order.Items;
using User;

namespace Order
{
    public class Order
    {
        public OrderType Type { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; } = new();
        
        public virtual void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public float GetOrderTotalPrice()
        {
            return Items.Sum(i => i.GetTotalPrice());
        }
    }
}
