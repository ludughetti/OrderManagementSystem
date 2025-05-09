using System.Collections.Generic;
using System.Linq;
using Order.Builders;
using Order.Items;
using Order.Items.ScriptableObjects;

namespace Order.Factories
{
    public abstract class OrderFactory
    {
        private List<OrderItem> _availableItems = new ();
        private OrderBuilder _orderBuilder;
        private OrderItemBuilder _orderItemBuilder;
        private string _activeOrderItemName;
        protected OrderType OrderType;

        public abstract void Initialize(List<OrderItemDataSource> availableItems);
        public abstract void PrepareOrder();

        public OrderType GetActiveOrderType()
        {
            return OrderType;
        }
        
        public List<OrderItem> GetOrderItems()
        {
            return _availableItems;
        }

        public List<AddOn> GetItemAddOns()
        {
            return _availableItems
                .FirstOrDefault(orderItem => _activeOrderItemName == orderItem.ItemName)?
                .AddOns;
        }

        public void StartNewOrder()
        {
            _orderBuilder = new OrderBuilder();
            _orderBuilder.WithType(OrderType);
        }

        public Order ConfirmOrder()
        {
            var order = _orderBuilder.Build();
            _orderBuilder = null;

            return order;
        }

        public void CancelOrder()
        {
            throw new System.NotImplementedException();
        }

        public void AddNewItem(string itemName)
        {
            _orderItemBuilder = new OrderItemBuilder();
            _orderItemBuilder.WithName(itemName);
            _activeOrderItemName = itemName;
        }

        public void ConfirmItem()
        {
            var newItem = _orderItemBuilder.Build();
            _orderBuilder.WithNewItem(newItem);
            _orderItemBuilder = null;
            _activeOrderItemName = null;
        }

        public void CancelItem()
        {
            _orderItemBuilder = null;
            _activeOrderItemName = null;
        }

        public void RemoveItem(string itemName)
        {
            throw new System.NotImplementedException();
        }

        public void AddNewAddOn(string addOnName)
        {
            _orderItemBuilder.WithNewAddOn(addOnName, "", 0.0f, null);
        }

        public void RemoveAddOn(string addOnName)
        {
            throw new System.NotImplementedException();
        }
        
        protected void ProcessOrderItemDataSource(OrderItemDataSource orderItemDataSource)
        {
            _availableItems.Add(new OrderItem(orderItemDataSource, OrderType));
        }
    }
}
