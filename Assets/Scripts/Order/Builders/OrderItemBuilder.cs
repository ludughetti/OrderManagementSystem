using System.Linq;
using Order.Items;
using UnityEngine;

namespace Order.Builders
{
    public class OrderItemBuilder
    {
        private readonly OrderItem _orderItem = new ();
        
        public OrderItemBuilder WithName(string name)
        {
            _orderItem.ItemName = name;
            return this;
        }

        public OrderItemBuilder WithDescription(string description)
        {
            _orderItem.ItemDescription = description;
            return this;
        }

        public OrderItemBuilder WithPrice(float price)
        {
            _orderItem.Price = price;
            return this;
        }

        public OrderItemBuilder WithIcon(Sprite icon)
        {
            _orderItem.Icon = icon;
            return this;
        }

        public OrderItemBuilder WithOrderType(OrderType orderType)
        {
            _orderItem.OrderType = orderType;
            return this;
        }

        public OrderItemBuilder WithNewAddOn(string addOnName, string addOnDescription, float addOnPrice, Sprite addOnIcon)
        {
            _orderItem.AddOns.Add(new AddOn(addOnName, addOnDescription, addOnPrice, addOnIcon));
            return this;
        }

        public OrderItemBuilder RemoveAddOn(string addOnName)
        {
            var addOnToRemove = _orderItem.AddOns.FirstOrDefault(addOn => addOn.AddOnName == addOnName);
            _orderItem.AddOns.Remove(addOnToRemove);
            return this;

        }

        public OrderItem Build()
        {
            return _orderItem;
        }
    }
}
