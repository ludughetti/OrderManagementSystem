using System.Collections.Generic;
using System.Linq;
using Order.Items.ScriptableObjects;
using UnityEngine;

namespace Order.Items
{
    public class OrderItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public float Price { get; set; }
        public Sprite Icon { get; set; }
        public OrderType OrderType { get; set; }
        public List<AddOn> AddOns { get; } = new ();
        
        // Constructor for Builder
        public OrderItem() { }
        
        // Constructor for parsing ScriptableObjects
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
