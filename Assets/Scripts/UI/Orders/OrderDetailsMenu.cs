using Order;
using UnityEngine;

namespace UI.Orders
{
    public class OrderDetailsMenu : MonoBehaviour
    {
        [SerializeField] private UIOrderDetailCard itemDetailPrefab;
        [SerializeField] private Transform cardContainer;
        
        [SerializeField] private OrderManager orderManager;
        
        private void OnEnable()
        {
            SetupCards();
        }

        private void SetupCards()
        {
            ClearCards();
            
            var orderItems = orderManager.GetActiveOrder();
            foreach (var item in orderItems)
            {
                var newItem = Instantiate(itemDetailPrefab, cardContainer);
                newItem.Setup(item, UpdateCards);
            }
        }

        private void UpdateCards(int itemId)
        {
            orderManager.RemoveItem(itemId);
            SetupCards();
        }
        
        private void ClearCards()
        {
            if (cardContainer == null)
                return;
                
            foreach (Transform child in cardContainer)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
