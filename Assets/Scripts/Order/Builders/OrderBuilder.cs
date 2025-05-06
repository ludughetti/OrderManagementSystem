using Order.Items;
using Order.ScriptableObjects;

namespace Order.Builders
{
    public class OrderBuilder
    {
        private readonly Order _order = new();
        
        public void WithType(OrderType orderType)
        {
            _order.Type = orderType;
        }

        public void WithNewItem(OrderItem orderItem)
        {
            _order.Items.Add(orderItem);
        }

        public Order Build()
        {
            return _order;
        }
    }
}
