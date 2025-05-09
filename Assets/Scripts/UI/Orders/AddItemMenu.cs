using TMPro;
using UnityEngine;

namespace UI.Orders
{
    public class AddItemMenu : OrderMenu
    {
        [SerializeField] private TMP_Text orderTotalText;
        
        protected override void LoadScreenData()
        {
            Debug.Log("Add Item Menu loading...");
            var orderItems = orderManager.GetAvailableOrderItems();
            
            foreach (var itemCardData in orderItems)
                CreateCard(itemCardData, navigationManager.GoToAddAddOnScreen);
            
            orderTotalText.text = orderManager.GetTotalPrice();
            
            Debug.Log("Add Item Menu finished loading.");
        }
    }
}
