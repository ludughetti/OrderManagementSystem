using System.Collections.Generic;
using Order.Items;
using Order.Items.ScriptableObjects;

namespace Order.Factories
{
    public interface IOrderFactory
    {
        void Initialize(List<OrderItemDataSource> availableItems);
        List<OrderItem> GetOrderItems();
        void StartNewOrder();
        Order ConfirmOrder();
        void CancelOrder();
        void PrepareOrder();
        void AddNewItem(string itemName);
        void ConfirmItem();
        void CancelItem();
        void RemoveItem(string itemName);
        void AddNewAddOn(string addOnName);
        void RemoveAddOn(string addOnName);
    }
}
