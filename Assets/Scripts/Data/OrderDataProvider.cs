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
        [SerializeField] private List<OrderDataSource> data;

        private Dictionary<OrderType, List<OrderItemDataSource>> _itemsByOrderType;

        private void Awake()
        {
            _itemsByOrderType = new Dictionary<OrderType, List<OrderItemDataSource>>();
            List<OrderItemDataSource> allAvailableOrderItems = new ();
            
            foreach (var item in data)
            {
                _itemsByOrderType.Add(item.type, item.orderItems);
                allAvailableOrderItems.AddRange(item.orderItems);
            }

            // Cleanup list to include unique items only (in case a DataSource was duplicated by mistake in the list)
            var uniqueOrderItems = allAvailableOrderItems
                                                        .GroupBy(item => item.itemName)
                                                        .Select(item => item.First())
                                                        .ToList();

            _itemsByOrderType.Add(OrderType.Combo, uniqueOrderItems);
        }

        public List<OrderItemDataSource> GetOrderItems(OrderType orderType)
        {
            return _itemsByOrderType[orderType];
        }
    }
}
