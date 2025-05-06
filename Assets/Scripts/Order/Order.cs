using System.Collections.Generic;
using System.Linq;
using Order.Items;

namespace Order
{
    public abstract class Order
    {
        public OrderType Type { get; protected set; }
        protected List<OrderItem> Items { get; }

        protected Order(OrderType type)
        {
            Type = type;
            Items = new List<OrderItem>();
        }
        
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
