using Order.Items;
using TMPro;
using UnityEngine;

namespace UI.Orders
{
    public class UIAddOnDetail : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text priceText;
        
        public void Setup(AddOn addOn)
        {
            nameText.text = addOn.AddOnName;
            priceText.text = addOn.Price.ToString();
        }
    }
}
