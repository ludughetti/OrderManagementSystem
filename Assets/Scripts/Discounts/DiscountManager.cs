using UnityEngine;

namespace Discounts
{
    public class DiscountManager
    {
        private const float BulkDiscount = 20.0f;
        private const float MembershipDiscount = 10.0f;

        public Order.Order ApplyDiscountStrategy(Order.Order order)
        {
            // Apply bulk discount
            if (order.Items.Count > 5)
            {
                Debug.Log("Applying bulk discount strategy");
                order = ApplyDiscount(order, BulkDiscount);
            } // Apply membership discount
            else if (order.Client.IsMember())
            {
                Debug.Log("Applying membership discount strategy");
                order = ApplyDiscount(order, MembershipDiscount);
            }
            
            return order;
        }

        private Order.Order ApplyDiscount(Order.Order order, float discountAmountPercentage)
        {
            foreach (var item in order.Items)
            {
                var itemDiscount = item.Price * (discountAmountPercentage / 100f);
                item.Price = item.Price - itemDiscount;

                foreach (var addOn in item.AddOns)
                {
                    var addOnDiscount = addOn.Price * (discountAmountPercentage / 100f);
                    addOn.Price = addOn.Price - addOnDiscount;
                }
            }
            
            return order;
        }
    }
}
