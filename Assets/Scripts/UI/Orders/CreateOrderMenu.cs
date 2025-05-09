using UnityEngine;

namespace UI.Orders
{
    public class CreateOrderMenu : OrderMenu
    {
        protected override void LoadScreenData()
        {
            Debug.Log("Create Order Menu loading...");
            var ordersCardData = orderManager.GetAvailableOrders();
            
            foreach (var orderCardData in ordersCardData)
                CreateCard(orderCardData, navigationManager.GoToAddItemScreen);
            
            Debug.Log("Create Order Menu finished loading.");
        }
    }
}
