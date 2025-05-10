using Navigation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Clients
{
    public class ClientMenu : MonoBehaviour
    {
        [Header("Client Data")]
        [SerializeField] private TMP_InputField clientNameField;
        [SerializeField] private TMP_InputField clientAddressField;
        [SerializeField] private TMP_InputField clientPhoneField;
        [SerializeField] private Toggle clientMemberToggle;
    
        [Header("Buttons")]
        [SerializeField] private Button confirmDataButton;
        [SerializeField] private Button cancelDataButton;
        
        [Header("Managers")]
        [SerializeField] private NavManager navigationManager;

        public void RegisterUserInfo()
        {
            var clientName = clientNameField.text;
            var clientAddress = clientAddressField.text;
            var clientPhone = clientPhoneField.text;
            var isMember = clientMemberToggle.isOn;
            
            CleanFields();
            navigationManager.SaveClientAndGoToCreateOrderScreen(clientName, clientAddress, clientPhone, isMember);
        }

        public void CancelUserInfo()
        {
            CleanFields();
            navigationManager.GoToMainMenuScreen();
        }

        private void CleanFields()
        {
            clientNameField.text = "";
            clientAddressField.text = "";
            clientPhoneField.text = "";
        }
    }
}
