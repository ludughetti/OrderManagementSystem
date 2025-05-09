using System;
using Order;
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

        public void Setup(ElementCardData data, Action<string> onClick)
        {
            nameText.text = data.Name;
            descriptionText.text = data.Description;
            iconImage.sprite = data.Icon;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => onClick?.Invoke(data.Id));
        }
    }
}
