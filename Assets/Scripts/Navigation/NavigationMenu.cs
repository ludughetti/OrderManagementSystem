using System;
using System.Collections.Generic;
using UnityEngine;

namespace Navigation
{
    public class NavigationMenu : MonoBehaviour
    {
        [Header("Menus")]
        [SerializeField] private MenuDataSource selfMenu;
        [SerializeField] private List<MenuDataSource> availableMenus;
    
        [Header("Buttons")]
        [SerializeField] private NavigationButton button;
        [SerializeField] private Transform buttonContainer;
    
        public event Action<string> OnMenuChange;
    
        private void Awake()
        {
            selfMenu.DataInstance = this;
        }
        
        public void Setup()
        {
            foreach (var id in availableMenus)
            {
                var newButton = Instantiate(button, buttonContainer);
                newButton.Setup(id.GetMenuId(), HandleButtonClick);
            }
        }
    
        private void HandleButtonClick(string id)
        {
            OnMenuChange?.Invoke(id);
        }
    }
}