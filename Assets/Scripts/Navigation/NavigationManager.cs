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
            for (var i = 0; i < availableMenus.Count; i++)
            {
                var menuWithId = availableMenus[i];

                if (menuWithId.GetMenuId() != id) 
                    continue;
            
                availableMenus[_currentMenuIndex].DataInstance.gameObject.SetActive(false);
                menuWithId.DataInstance.gameObject.SetActive(true);
                _currentMenuIndex = i;
                break;
            }
        }
    }
}