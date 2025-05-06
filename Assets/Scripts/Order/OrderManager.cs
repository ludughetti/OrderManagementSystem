using System;
using System.Collections.Generic;
using Data;
using Order.Factories;
using Order.Items;
using UnityEngine;

namespace Order
{
    public class OrderManager : MonoBehaviour
    {
        [SerializeField] private OrderDataProvider orderDataProvider;
        
        private Dictionary<OrderType, IOrderFactory> _factories;
        private IOrderFactory _activeFactory;
        
        private void Start()
        {
            InitializeOrderFactories();
        }

        private void InitializeOrderFactories()
        {
            foreach (OrderType orderType in Enum.GetValues(typeof(OrderType)))
            {
                 var newFactory = GetOrderFactory(orderType);
                 newFactory.Initialize(orderDataProvider.GetOrderItems(orderType));
                 
                 _factories[orderType] = newFactory;
            }
        }

        private static IOrderFactory GetOrderFactory(OrderType orderType)
        {
            return orderType switch
            {
                OrderType.Beverage => new BeverageFactory(),
                OrderType.Pastry => new PastryFactory(),
                OrderType.Sandwich => new SandwichFactory(),
                OrderType.IceCream => new IceCreamFactory(),
                OrderType.Combo => new ComboFactory(),
                _ => throw new ArgumentOutOfRangeException(nameof(orderType), orderType, null)
            };
        }

        public List<OrderItem> GetAvailableOrderItems(OrderType orderType)
        {
            return _factories[orderType].GetOrderItems();
        }

        public void CreateNewOrder(OrderType orderType)
        {
            _activeFactory = _factories[orderType];
            _activeFactory.StartNewOrder();
        }

        public Order ConfirmOrder()
        {
            var newOrder = _activeFactory.ConfirmOrder();
            _activeFactory = null;
            
            return newOrder;   
        }

        public void CancelOrder()
        {
            _activeFactory.CancelOrder();
            _activeFactory = null;
        }

        public void AddNewItem(string itemName)
        {
            _activeFactory.AddNewItem(itemName);
        }
        
        public void ConfirmItem()
        {
            _activeFactory.ConfirmItem();
        }

        public void CancelItem()
        {
            _activeFactory.CancelItem();
        }

        public void RemoveItem(string itemName)
        {
            _activeFactory.RemoveItem(itemName);
        }

        public void AddNewAddOn(string addOnName)
        {
            _activeFactory.AddNewAddOn(addOnName);
        }

        public void RemoveAddOn(string addOnName)
        {
            _activeFactory.RemoveAddOn(addOnName);
        }
    }
}
