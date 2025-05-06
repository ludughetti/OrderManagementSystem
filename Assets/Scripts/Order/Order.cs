using System.Collections.Generic;
using System.Linq;
using Order.Items;

namespace Order
{
    public class Order
    {
        public OrderType Type { get; set; }
        public List<OrderItem> Items { get; set; }
        
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
