using System.Collections.Generic;
using System.Linq;
using Order.Items.ScriptableObjects;
using UnityEngine;

namespace Order.Items
{
    public class OrderItem
    {
        public string ItemName { get; private set; }
        public string ItemDescription { get; private set; }
        public float Price { get; private set; }
        public Sprite Icon { get; private set; }
        public OrderType OrderType { get; private set; }
        private List<AddOn> AddOns { get; }
        
        // Initialization for UI display
        public OrderItem(OrderItemDataSource orderItemDataSource, OrderType orderType)
        {
            ItemName = orderItemDataSource.itemName;
            ItemDescription = orderItemDataSource.itemDescription;
            Price = orderItemDataSource.basePrice;
            Icon = orderItemDataSource.icon;
            OrderType = orderType;
            AddOns = new List<AddOn>();
            
            foreach(var addOnDataSource in orderItemDataSource.addOns)
                AddOns.Add(new AddOn(addOnDataSource));
        }

        public float GetTotalPrice()
        {
            return Price + AddOns.Sum(addOn => addOn.Price);
        }
    }
}
