using Order.Items;
using UnityEngine;

namespace Order.Builders
{
    public class OrderItemBuilder
    {
        private readonly OrderItem _orderItem = new ();
        
        public void WithName(string name)
        {
            _orderItem.ItemName = name;
        }

        public void WithDescription(string description)
        {
            _orderItem.ItemDescription = description;
        }

        public void WithPrice(float price)
        {
            _orderItem.Price = price;
        }

        public void WithIcon(Sprite icon)
        {
            _orderItem.Icon = icon;
        }

        public void WithOrderType(OrderType orderType)
        {
            _orderItem.OrderType = orderType;
        }

        public void WithNewAddOn(string addOnName, string addOnDescription, float addOnPrice, Sprite addOnIcon)
        {
            _orderItem.AddOns.Add(new AddOn(addOnName, addOnDescription, addOnPrice, addOnIcon));
        }

        public OrderItem Build()
        {
            return _orderItem;
        }
    }
}
