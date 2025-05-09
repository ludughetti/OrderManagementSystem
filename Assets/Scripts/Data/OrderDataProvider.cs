using System.Collections.Generic;
using System.Linq;
using Order;
using Order.Items.ScriptableObjects;
using Order.ScriptableObjects;
using UnityEngine;

namespace Data
{
    public class OrderDataProvider : MonoBehaviour
    {
        [SerializeField] private List<OrderDataSource> ordersData;

        private List<OrderDataSource> _availableOrders = new ();
        private Dictionary<OrderType, List<OrderItemDataSource>> _availableItemsByOrder;

        private void Awake()
        {
            _availableOrders = ordersData.GroupBy(order => order.type)
                .Select(order => order.First())
                .ToList();
            
            _availableItemsByOrder = new Dictionary<OrderType, List<OrderItemDataSource>>();
            List<OrderItemDataSource> allAvailableOrderItems = new ();
            
            foreach (var item in ordersData)
            {
                _availableItemsByOrder.Add(item.type, item.orderItems);
                allAvailableOrderItems.AddRange(item.orderItems);
            }

            // Cleanup list to include unique items only (in case a DataSource was duplicated by mistake in the list)
            var uniqueOrderItems = allAvailableOrderItems
                                                        .GroupBy(item => item.itemName)
                                                        .Select(item => item.First())
                                                        .ToList();

            _availableItemsByOrder[OrderType.Combo] = uniqueOrderItems;
        }

        public List<OrderDataSource> GetOrders()
        {
            return _availableOrders;
        }

        public List<OrderItemDataSource> GetItemsByOrderType(OrderType orderType)
        {
            return _availableItemsByOrder[orderType];
        }
    }
}
