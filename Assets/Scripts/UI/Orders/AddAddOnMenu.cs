using UnityEngine;

namespace UI.Orders
{
    public class AddAddOnMenu : OrderMenu
    {
        protected override void LoadScreenData()
        {
            Debug.Log("Add Add-On Menu loading...");
            var itemAddOns = orderManager.GetAvailableAddOns();
            
            foreach (var addOnCardData in itemAddOns)
                CreateCard(addOnCardData, navigationManager.AddNewAddOn);
            
            Debug.Log("Add Add-On Menu finished loading.");
        }
    }
}
