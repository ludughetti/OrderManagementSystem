using System;
using Order.DTO;
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
                CreateCard(addOnCardData, navigationManager.ToggleAddOn);
            
            Debug.Log("Add Add-On Menu finished loading.");
        }

        private void CreateCard(ElementCardData data, Action<string, bool> onClick)
        {
            var card = Instantiate(uiElementCardPrefab, cardContainer);
            card.Setup(data, onClick);
        }
    }
}
