using System;
using Order.DTO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Orders
{
    public class UIElementCard : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private Image iconImage;
        [SerializeField] private Button button;
        [SerializeField] private Image backgroundImage;
        
        private Action<string, bool> _toggleAction;
        private bool _isSelected;
        private string _id;
        
        public void Setup(ElementCardData data, Action<string> onClick)
        {
            nameText.text = data.Name;
            descriptionText.text = data.Description;
            iconImage.sprite = data.Icon;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => onClick?.Invoke(data.Id));
        }
        
        public void Setup(ElementCardData data, Action<string, bool> onClick)
        {
            nameText.text = data.Name;
            descriptionText.text = data.Description;
            iconImage.sprite = data.Icon;
            
            _id = data.Id;
            _toggleAction = onClick;
            
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(HandleClick);
        }

        private void HandleClick()
        {
            // Toggle the button
            _isSelected = !_isSelected;
            UpdateVisual();
            
            // Trigger backend action
            _toggleAction?.Invoke(_id, _isSelected);
        }

        private void UpdateVisual()
        {
            backgroundImage.color = _isSelected ? new Color(200, 200, 200) : Color.white;
        }
    }
}
