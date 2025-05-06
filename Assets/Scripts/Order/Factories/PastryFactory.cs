using System.Collections.Generic;
using Order.Builders;
using Order.Items;
using Order.Items.ScriptableObjects;
using UnityEngine;
using static Order.OrderType;

namespace Order.Factories
{
    public class PastryFactory : IOrderFactory
    {
        private readonly List<OrderItem> _availableItems = new ();
        private OrderBuilder _orderBuilder;
        private OrderItemBuilder _orderItemBuilder;
        private const OrderType OrderType = Pastry;

        public void Initialize(List<OrderItemDataSource> availableItems)
        {
            foreach (var availableItem in availableItems)
                ProcessOrderItemDataSource(availableItem);
        }

        public List<OrderItem> GetOrderItems()
        {
            return _availableItems;
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

        public void PrepareOrder()
        {
            // TODO: Implement mock process for notifications
            Debug.Log("Preparing Pastry Order");
        }

        public void AddNewItem(string itemName)
        {
            _orderItemBuilder = new OrderItemBuilder();
            _orderItemBuilder.WithName(itemName);
        }

        public void ConfirmItem()
        {
            var newItem = _orderItemBuilder.Build();
            _orderBuilder.WithNewItem(newItem);
            _orderItemBuilder = null;
        }

        public void CancelItem()
        {
            _orderItemBuilder = null;
        }

        public void RemoveItem(string itemName)
        {
            throw new System.NotImplementedException();
        }

        public void AddNewAddOn(string addOnName)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAddOn(string addOnName)
        {
            throw new System.NotImplementedException();
        }

        private void ProcessOrderItemDataSource(OrderItemDataSource orderItemDataSource)
        {
            _availableItems.Add(new OrderItem(orderItemDataSource, OrderType));
        }
    }
}
