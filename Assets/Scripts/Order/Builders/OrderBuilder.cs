using System.Collections.Generic;
using System.Linq;
using Order.Items;
using User;
using User.Clients;

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

        public OrderBuilder WithClient(Client client)
        {
            _order.Client = client;
            return this;
        }

        public OrderBuilder WithNewItem(OrderItem orderItem)
        {
            orderItem.ItemId = GetNewItemId(0);
            _order.Items.Add(orderItem);
            
            return this;
        }

        public OrderBuilder RemoveItem(string orderItemName)
        {
            var itemToRemove = _order.Items.FirstOrDefault(item => item.ItemName == orderItemName); 
            _order.Items.Remove(itemToRemove);
            return this;
        }
        
        public OrderBuilder RemoveItem(int orderItemId)
        {
            var itemToRemove = _order.Items.FirstOrDefault(item => item.ItemId == orderItemId); 
            _order.Items.Remove(itemToRemove);
            return this;
        }
        
        public List<OrderItem> GetOrderItems()
        {
            return _order.Items;
        }

        public Order Build()
        {
            return _order;
        }

        // Verify recursively all existing order items to check for the first Item Id not in use yet
        private int GetNewItemId(int id)
        {
            return _order.Items.Any(item => item.ItemId == id) 
                ? GetNewItemId(id + 1) 
                : id;
        }
    }
}
