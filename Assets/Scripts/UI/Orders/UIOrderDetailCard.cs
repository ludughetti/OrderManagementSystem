using System;
using Order.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Orders
{
    public class UIOrderDetailCard : MonoBehaviour
    {
        [SerializeField] private TMP_Text itemNameText;
        [SerializeField] private TMP_Text itemPriceText;
        [SerializeField] private TMP_Text totalItemPriceText;
        [SerializeField] private Image iconImage;
        [SerializeField] private Transform addOnDetailContainer;
        [SerializeField] private Button removeItemButton;
        [SerializeField] private UIAddOnDetail addOnDetailPrefab;

        public void Setup(OrderItem orderItem, Action<int> onClick)
        {
            itemNameText.text = orderItem.ItemName;
            itemPriceText.text = orderItem.Price.ToString();
            totalItemPriceText.text = orderItem.GetTotalPrice().ToString();
            iconImage.sprite = orderItem.Icon;

            foreach (var addOn in orderItem.AddOns)
            {
                var detail = Instantiate(addOnDetailPrefab, addOnDetailContainer);
                detail.Setup(addOn);
            }
            
            removeItemButton.onClick.RemoveAllListeners();
            removeItemButton.onClick.AddListener(() => onClick?.Invoke(orderItem.ItemId));
        }
    }
}
