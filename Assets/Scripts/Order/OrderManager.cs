using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Discounts;
using Notifications;
using Order.DTO;
using Order.Factories;
using Order.Items;
using UnityEngine;
using User;
using User.Clients;
using User.Employees;

namespace Order
{
    public class OrderManager : MonoBehaviour
    {
        [SerializeField] private OrderDataProvider orderDataProvider;
        
        private ClientManager _clientManager = new ();
        private EmployeeManager _employeeManager = new ();
        private NotificationManager _notificationManager;
        
        private DiscountManager _discountManager = new ();
        
        private Dictionary<OrderType, OrderFactory> _factories = new ();
        private OrderFactory _activeFactory;
        private Client _activeClient;

        private int _userIdCount;
        
        private void Start()
        {
            _notificationManager = new NotificationManager(_clientManager, _employeeManager);
            InitializeOrderFactories();
        }

        private void InitializeOrderFactories()
        {
            foreach (var order in orderDataProvider.GetOrders())
            {
                 var newFactory = GetOrderFactory(order.type);
                 newFactory.Initialize(orderDataProvider.GetItemsByOrderType(order.type), _notificationManager, _discountManager);
                 
                 _factories.TryAdd(order.type, newFactory);
            }
        }

        private OrderFactory GetOrderFactory(OrderType orderType)
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

        public void SaveClientData(string clientName, string clientAddress, string clientPhone, bool isMember)
        {
            _userIdCount++;
            Debug.Log($"Saving active client data: {_userIdCount}, {clientName}, {clientAddress}, {clientPhone}");
            
            var client = new Client(clientName, clientAddress, clientPhone, isMember);
            client.SetUserId(_userIdCount);
            
            _clientManager.AddActiveClient(client);
            
            _activeClient = client;
        }

        public List<ElementCardData> GetAvailableOrders()
        {
            return orderDataProvider
                .GetOrders()
                .Select(order => new ElementCardData(order.orderName, order.orderDescription, 
                                                     order.orderIcon, order.type.ToString()))
                .ToList();
        }

        public List<ElementCardData> GetAvailableOrderItems()
        {
            return _activeFactory
                .GetAvailableOrderItems()
                .Select(orderItem => new ElementCardData(orderItem.ItemName, orderItem.ItemDescription, 
                                                         orderItem.Icon, orderItem.ItemName))
                .ToList();
        }
        
        public List<ElementCardData> GetAvailableAddOns()
        {
            return _activeFactory
                .GetItemAddOns()
                .Select(addOn => new ElementCardData(addOn.AddOnName, addOn.AddOnDescription,
                                                     addOn.Icon, addOn.AddOnName))
                .ToList();
        }

        public void CreateNewOrder(string orderTypeValue)
        {
            var orderType = (OrderType) Enum.Parse(typeof(OrderType), orderTypeValue);
            
            _activeFactory = _factories[orderType];
            _activeFactory.StartNewOrder(_activeClient);
        }

        public Order ConfirmOrder()
        {
            var newOrder = _activeFactory.ConfirmOrder();
            _activeFactory = null;
            _activeClient = null;
            
            return newOrder;   
        }

        public void CancelOrder()
        {
            _clientManager.RemoveActiveClient(_activeClient);
            _activeClient = null;
            
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

        public void RemoveItem(int itemId)
        {
            _activeFactory.RemoveItem(itemId);
        }

        public void AddNewAddOn(string addOnName)
        {
            _activeFactory.AddNewAddOn(addOnName);
        }

        public void RemoveAddOn(string addOnName)
        {
            _activeFactory.RemoveAddOn(addOnName);
        }

        public string GetTotalPrice()
        {
            var tempOrder = _activeFactory.GetActiveOrder();
            _discountManager.ApplyDiscountStrategy(tempOrder);
            return tempOrder.GetOrderTotalPrice().ToString();
        }

        public List<OrderItem> GetActiveOrder()
        {
            return _activeFactory.GetActiveOrderItems();
        }
    }
}
