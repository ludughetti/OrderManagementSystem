using System.Collections.Generic;
using Order.Items.ScriptableObjects;
using UnityEngine;
using static Order.OrderType;

namespace Order.Factories
{
    public class SandwichFactory : OrderFactory
    {
        public override void Initialize(List<OrderItemDataSource> availableItems)
        {
            foreach (var availableItem in availableItems)
                ProcessOrderItemDataSource(availableItem);
            
            OrderType = Sandwich;
        }
        
        public override void PrepareOrder()
        {
            //TODO: Mock process for notification service
            Debug.Log("Sandwich order being prepared...");
        }
    }
}
