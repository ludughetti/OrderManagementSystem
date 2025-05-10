using Order;
using UnityEngine;

namespace Navigation
{
    public class NavManager : MonoBehaviour
    {
        [Header("Screens")]
        [SerializeField] private GameObject mainMenuScreen;
        [SerializeField] private GameObject clientInfoScreen;
        [SerializeField] private GameObject createOrderScreen;
        [SerializeField] private GameObject addItemScreen;
        [SerializeField] private GameObject addAddOnScreen;
        [SerializeField] private GameObject editOrderScreen;
        [SerializeField] private GameObject confirmOrderScreen;

        [Header("Managers")]
        [SerializeField] private OrderManager orderManager;
    
        private GameObject _currentScreen;

        private void Start()
        {
            mainMenuScreen.SetActive(true);
            clientInfoScreen.SetActive(false);
            createOrderScreen.SetActive(false);
            addItemScreen.SetActive(false);
            addAddOnScreen.SetActive(false);
            editOrderScreen.SetActive(false);
            confirmOrderScreen.SetActive(false);
        }

        public void GoToMainMenuScreen()
        {
            ShowScreen(mainMenuScreen);
        }

        public void GoToClientInfoScreen()
        {
            ShowScreen(clientInfoScreen);
        }
    
        public void GoToCreateOrderScreen()
        {
            ShowScreen(createOrderScreen);
        }
        
        public void SaveClientAndGoToCreateOrderScreen(string clientName, string clientAddress, string clientPhone, bool isMember)
        {
            orderManager.SaveClientData(clientName, clientAddress, clientPhone, isMember);
            ShowScreen(createOrderScreen);
        }

        public void ConfirmOrder()
        {
            orderManager.ConfirmOrder();
            ShowScreen(mainMenuScreen);
        }

        public void CancelOrder()
        {
            orderManager.CancelOrder();
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

        public void ToggleAddOn(string addOnName, bool isSelected)
        {
            if (isSelected)
                orderManager.AddNewAddOn(addOnName);
            else 
                orderManager.RemoveAddOn(addOnName);
        }

        public void GoToEditOrderScreen()
        {
            ShowScreen(editOrderScreen);
        }

        public void ConfirmItem()
        {
            orderManager.ConfirmItem();
            GoToAddItemScreen();
        }

        public void CancelItem()
        {
            orderManager.CancelItem();
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
