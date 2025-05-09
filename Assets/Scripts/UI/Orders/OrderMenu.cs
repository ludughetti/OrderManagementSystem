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
        [SerializeField] private NavigationManager navigationManager;
        
        [Header("UI Handlers")]
        [SerializeField] private MenuDataSource selfMenuData;
        [SerializeField] protected UIElementCard uiElementCardPrefab;
        [SerializeField] protected Transform cardContainer;

        private void OnEnable()
        {
            navigationManager.OnScreenChanged += HandleScreenChanged;
        }

        private void OnDisable()
        {
            navigationManager.OnScreenChanged -= HandleScreenChanged;
        }

        private void HandleScreenChanged(string screenId)
        {
            if (selfMenuData.GetMenuId() != screenId) 
                return;
            
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
