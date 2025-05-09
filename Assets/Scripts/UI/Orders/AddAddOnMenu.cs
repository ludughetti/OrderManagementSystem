using System;
using Order.DTO;
using TMPro;
using UnityEngine;

namespace UI.Orders
{
    public class AddAddOnMenu : OrderMenu
    {
        [SerializeField] private TMP_Text orderTotalText;
        
        protected override void LoadScreenData()
        {
            Debug.Log("Add Add-On Menu loading...");
            var itemAddOns = orderManager.GetAvailableAddOns();
            
            foreach (var addOnCardData in itemAddOns)
                CreateCard(addOnCardData, navigationManager.ToggleAddOn);
            
            orderTotalText.text = orderManager.GetTotalPrice();
            
            Debug.Log("Add Add-On Menu finished loading.");
        }

        private void CreateCard(ElementCardData data, Action<string, bool> onClick)
        {
            var card = Instantiate(uiElementCardPrefab, cardContainer);
            card.Setup(data, onClick);
        }
    }
}
