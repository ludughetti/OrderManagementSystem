using Order;
using UnityEngine;

namespace Navigation
{
    public class NavManager : MonoBehaviour
    {
        [Header("Screens")]
        [SerializeField] private GameObject mainMenuScreen;
        [SerializeField] private GameObject createOrderScreen;
        [SerializeField] private GameObject addItemScreen;
        [SerializeField] private GameObject addAddOnScreen;
        [SerializeField] private GameObject confirmOrderScreen;

        [Header("Managers")]
        [SerializeField] private OrderManager orderManager;
    
        private GameObject _currentScreen;

        private void Start()
        {
            // TODO: clean up
            createOrderScreen.SetActive(false);
            addItemScreen.SetActive(false);
            addAddOnScreen.SetActive(false);
            confirmOrderScreen.SetActive(false);
        }

        public void GoToMainMenuScreen()
        {
            ShowScreen(mainMenuScreen);
        }
    
        public void GoToCreateOrderScreen()
        {
            ShowScreen(createOrderScreen);
        }

        public void ConfirmOrder()
        {
            orderManager.ConfirmOrder();
            ShowScreen(mainMenuScreen);
        }

        // This method will be used to kickstart the order creation
        public void GoToAddItemScreen(string orderType)
        {
            orderManager.CreateNewOrder(orderType);
            ShowScreen(addItemScreen);
        }
    
        // This method will be used to return to Add Item after adding another item
        private void GoToAddItemScreen()
        {
            ShowScreen(addItemScreen);
        }
    
        public void GoToAddAddOnScreen(string itemId)
        {
            orderManager.AddNewItem(itemId);
            ShowScreen(addAddOnScreen);
        }

        public void AddNewAddOn(string addOnName)
        {
            orderManager.AddNewAddOn(addOnName);
        }

        public void ConfirmItem()
        {
            orderManager.ConfirmItem();
            GoToAddItemScreen();
        }
    
        public void GoToConfirmOrderScreen()
        {
            ShowScreen(confirmOrderScreen);
        }

        private void ShowScreen(GameObject screen)
        {
            if (_currentScreen != null)
                _currentScreen.SetActive(false);

            screen.SetActive(true);
            _currentScreen = screen;
        }
    }
}
