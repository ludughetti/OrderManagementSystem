using UnityEngine;

namespace UI.Orders
{
    public class AddItemMenu : OrderMenu
    {
        protected override void LoadScreenData()
        {
            Debug.Log("Add Item Menu loading...");
            var orderItems = orderManager.GetAvailableOrderItems();
            
            foreach (var itemCardData in orderItems)
                CreateCard(itemCardData, navigationManager.GoToAddAddOnScreen);
            
            Debug.Log("Add Item Menu finished loading.");
        }
    }
}
