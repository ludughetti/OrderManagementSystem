using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Navigation
{
    public class NavigationManager : MonoBehaviour
    {
        [Header("Menus")]
        [SerializeField] private MenuDataSource mainMenu;
        [SerializeField] private List<MenuDataSource> availableMenus;
    
        private int _currentMenuIndex;

        public Action<string> OnScreenChanged;

        private void Start()
        {
            foreach (var menu in availableMenus.Where(menu => menu.DataInstance != null))
            {
                menu.DataInstance.Setup();
                menu.DataInstance.OnMenuChange += HandleMenuChange;
                menu.DataInstance.gameObject.SetActive(false);
            }

            if (availableMenus.Count > 0)
            {
                availableMenus[_currentMenuIndex].DataInstance.gameObject.SetActive(true);
            }
        }

        private void HandleMenuChange(string id)
        {
            var target = availableMenus.Find(m => m.GetMenuId() == id);
            if (target == null) return;

            availableMenus[_currentMenuIndex].DataInstance.gameObject.SetActive(false);
            target.DataInstance.gameObject.SetActive(true);
            _currentMenuIndex = availableMenus.IndexOf(target);

            // Trigger event in case there's any menu-specific config needed
            // Such as loading order items in the Add Item screen
            OnScreenChanged?.Invoke(id);
        }
    }
}