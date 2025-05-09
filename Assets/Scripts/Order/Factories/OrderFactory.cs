using System.Collections.Generic;
using System.Linq;
using Order.Builders;
using Order.Items;
using Order.Items.ScriptableObjects;
using UnityEngine;

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
            Debug.Log($"Starting new order with type { OrderType.ToString() }");
            _orderBuilder = new OrderBuilder();
            _orderBuilder.WithType(OrderType);
        }

        public Order ConfirmOrder()
        {
            Debug.Log($"Confirming new order with type { OrderType.ToString() }");
            var order = _orderBuilder.Build();
            _orderBuilder = null;

            return order;
        }

        public void CancelOrder()
        {
            Debug.Log($"Cancelling new order with type { OrderType.ToString() }");
            _orderBuilder = null;
            
            if(_orderItemBuilder != null)
                CancelItem();
        }

        public void AddNewItem(string itemName)
        {
            Debug.Log($"Adding new item with name { itemName }");
            
            _activeOrderItemName = itemName;
            _orderItemBuilder = new OrderItemBuilder();
            var orderItem = _availableItems.FirstOrDefault(orderItem => orderItem.ItemName == itemName);

            // Should not happen as all items should be in the list,
            // but we check just in case
            if (orderItem == null)
            {
                _orderItemBuilder.WithName(itemName)
                                 .WithOrderType(OrderType);
                return;
            }
            
            _orderItemBuilder.WithName(orderItem.ItemName)
                             .WithDescription(orderItem.ItemDescription)
                             .WithPrice(orderItem.Price)
                             .WithIcon(orderItem.Icon)
                             .WithOrderType(orderItem.OrderType);
        }

        public void ConfirmItem()
        {
            Debug.Log($"Confirming new item with name { _activeOrderItemName }");
            var newItem = _orderItemBuilder.Build();
            _orderBuilder.WithNewItem(newItem);
            
            // Reset for next
            _orderItemBuilder = null;
            _activeOrderItemName = null;
        }

        public void CancelItem()
        {
            Debug.Log($"Cancelling new item with name { _activeOrderItemName }");
            _orderItemBuilder = null;
            _activeOrderItemName = null;
        }

        public void RemoveItem(string itemName)
        {
            Debug.Log($"Removing item with name { itemName }");
            _orderBuilder.RemoveItem(itemName);
        }

        public void AddNewAddOn(string addOnName)
        {
            Debug.Log($"Adding new add-on with name { addOnName }");
            _orderItemBuilder.WithNewAddOn(addOnName, "", 0.0f, null);
        }

        public void RemoveAddOn(string addOnName)
        {
            Debug.Log($"Removing new add-on with name { addOnName }");
            _orderItemBuilder.RemoveAddOn(addOnName);
        }
        
        protected void ProcessOrderItemDataSource(OrderItemDataSource orderItemDataSource)
        {
            _availableItems.Add(new OrderItem(orderItemDataSource, OrderType));
        }
    }
}
