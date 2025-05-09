using System.Linq;
using Order.Items;
using Order.ScriptableObjects;

namespace Order.Builders
{
    public class OrderBuilder
    {
        private readonly Order _order = new();
        
        public OrderBuilder WithType(OrderType orderType)
        {
            _order.Type = orderType;
            return this;
        }

        public OrderBuilder WithNewItem(OrderItem orderItem)
        {
            _order.Items.Add(orderItem);
            return this;
        }

        public OrderBuilder RemoveItem(string orderItemName)
        {
            var itemToRemove = _order.Items.FirstOrDefault(item => item.ItemName == orderItemName); 
            _order.Items.Remove(itemToRemove);
            return this;
        }

        public Order Build()
        {
            return _order;
        }
    }
}
