using System;
using Navigation;
using Order;
using Order.DTO;
using UnityEngine;

namespace UI.Orders
{
    public abstract class OrderMenu : MonoBehaviour
    {
        [Header("Managers")]
        [SerializeField] protected OrderManager orderManager;
        [SerializeField] protected NavManager navigationManager;
        
        [Header("UI Handlers")]
        [SerializeField] protected UIElementCard uiElementCardPrefab;
        [SerializeField] protected Transform cardContainer;

        private void OnEnable()
        {
            ClearCards();
            LoadScreenData();
        }
        
        private void ClearCards()
        {
            if (cardContainer == null)
                return;
                
            foreach (Transform child in cardContainer)
            {
                Destroy(child.gameObject);
            }
        }
        
        protected void CreateCard(ElementCardData data, Action<string> onClick)
        {
            var card = Instantiate(uiElementCardPrefab, cardContainer);
            card.Setup(data, onClick);
        }

        protected abstract void LoadScreenData();
    }
}
