using System.Collections;
using System.Collections.Generic;
using Discounts;
using Notifications;
using Order.Items.ScriptableObjects;
using UnityEngine;
using Utils;
using static Order.OrderType;

namespace Order.Factories
{
    public class PastryFactory : OrderFactory
    {
        public override void Initialize(List<OrderItemDataSource> availableItems, NotificationManager notificationManager, DiscountManager discountManager)
        {
            _notificationManager = notificationManager;
            _discountManager = discountManager;
            
            foreach (var availableItem in availableItems)
                ProcessOrderItemDataSource(availableItem);
            
            OrderType = Pastry;
        }
        
        public override void PrepareOrder(Order order)
        {
            //TODO: Mock process for notification service
            Debug.Log("Pastry order being prepared...");
            
            CoroutineRunner.Run(PrepareOrderCoroutine(order));
        }
        
        // This is a mocked process to trigger changes for notification service 
        private IEnumerator PrepareOrderCoroutine(Order order)
        {
            // Setup observers
            _notificationManager.ObserveOrderProgress(order);

            // Received order
            order.UpdateStatus(OrderStatus.New);
            yield return new WaitForSeconds(5f);
            
            // Preparing order
            order.UpdateStatus(OrderStatus.Preparing);
            PrepareDough();
            yield return new WaitForSeconds(5f);
            CookDough();
            yield return new WaitForSeconds(5f);
            AddExtras();
            yield return new WaitForSeconds(5f);
            
            // Waiting to deliver order
            order.UpdateStatus(OrderStatus.ReadyToDeliver);
            DeliverOrder();
            yield return new WaitForSeconds(5f);
            
            // Delivered order
            order.UpdateStatus(OrderStatus.Delivered);
            FinalizeProcess(order.Type);
        }

        private void PrepareDough()
        {
            Debug.Log("Preparing dough...");
        }

        private void CookDough()
        {
            Debug.Log("Putting dough in oven...");
        }

        private void AddExtras()
        {
            Debug.Log("Adding extras...");
        }

        private void DeliverOrder()
        {
            Debug.Log("Delivering order...");
        }

        private void FinalizeProcess(OrderType orderType)
        {
            Debug.Log("Order delivered. Thank you!");
            _notificationManager.FinalizeProcess(orderType);
        }
    }
}
