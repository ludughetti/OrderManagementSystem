using System.Collections.Generic;
using Order.Items.ScriptableObjects;
using UnityEngine;
using static Order.OrderType;

namespace Order.Factories
{
    public class IceCreamFactory : OrderFactory
    {
        public override void Initialize(List<OrderItemDataSource> availableItems)
        {
            foreach (var availableItem in availableItems)
                ProcessOrderItemDataSource(availableItem);
            
            OrderType = IceCream;
        }
        
        public override void PrepareOrder()
        {
            //TODO: Mock process for notification service
            Debug.Log("IceCream order being prepared...");
        }
    }
}
